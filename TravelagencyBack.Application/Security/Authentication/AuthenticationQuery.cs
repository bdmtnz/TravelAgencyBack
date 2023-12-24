using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TravelagencyBack.Application.Base;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.Contracts;
using TravelAgencyBack.Domain.Resources;

namespace TravelagencyBack.Application.Security.Authentication
{
    public class AuthenticationQuery : IRequestHandler<AuthenticationRequest, ApiResponse<AuthenticationResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<AuthenticationResponse>> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            var credentialRepository = _unitOfWork.GenericRepository<Credential>();
            ApiResponse<AuthenticationResponse> response;
            if (credentialRepository is null)
            {
                response = new ApiResponse<AuthenticationResponse>()
                {
                    Data = default,
                    Message = Resources.ErrorResponsesES.INTERNAL_SERVER_ERROR,
                    Status = HttpStatusCode.InternalServerError
                };
                return response;
            }

            var credential = credentialRepository.FindBy(
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
                    Name = credential.Contact.Name,
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
