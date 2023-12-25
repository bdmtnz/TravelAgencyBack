using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.Contracts;
using TravelAgencyBack.Domain.Resources;

namespace TravelAgencyBack.Application.Security.Authentication
{
    public class AuthenticationQuery : IRequestHandler<AuthenticationRequest, ApiResponse<AuthenticationResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Credential> _credentialRepository;

        public AuthenticationQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _credentialRepository = _unitOfWork.GenericRepository<Credential>();
            var credentials = _credentialRepository.GetAll();
            if(!credentials.Any())
            {
                var seedCredential = new List<Credential>()
                {
                    new Credential(
                        "admin@admin.com",
                        "Admin",
                        "", 
                        Rol.Agency,
                        new TravelAgencyBack.Domain.ValueObjects.Phone(57, "3116390221")
                    )
                };
                _credentialRepository.AddRange(seedCredential);
                _unitOfWork.Commit();
            }
        }

        public async Task<ApiResponse<AuthenticationResponse>> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<AuthenticationResponse> response;
            if (_credentialRepository is null)
            {
                response = new ApiResponse<AuthenticationResponse>()
                {
                    Data = default,
                    Message = Resources.ErrorResponsesES.INTERNAL_SERVER_ERROR,
                    Status = HttpStatusCode.InternalServerError
                };
                return response;
            }
            //var credentials = _credentialRepository.GetAll();
            var credential = _credentialRepository.FindBy(
                    credential =>
                        credential.User == request.User &&
                        credential.Password == request.Password &&
                        credential.Enabled
                ).FirstOrDefault();
            if (credential is null)
            {
                response = new ApiResponse<AuthenticationResponse>()
                {
                    Data = default,
                    Message = Resources.ErrorResponsesES.INVALID_CREDENTIALS,
                    Status = HttpStatusCode.NotFound
                };
                return response;
            }

            response = new ApiResponse<AuthenticationResponse>()
            {
                Data = new AuthenticationResponse()
                {
                    Id = credential.Id,
                    Name = credential.Name,
                    Rol = new EnumResponse<Rol>(credential.Rol),
                    Token = Guid.NewGuid().ToString()
                },
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Status = HttpStatusCode.OK
            };
            return response;

        }
    }
}
