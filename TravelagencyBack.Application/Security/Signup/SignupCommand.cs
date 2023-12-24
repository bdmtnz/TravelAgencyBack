using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelagencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Contracts;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelagencyBack.Application.Security.Signup
{
    public class SignupCommand : IRequestHandler<SignupRequest, ApiResponse<object>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Traveler> _travelRepository;

        public SignupCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _travelRepository = unitOfWork.GenericRepository<Traveler>();
        }

        public Task<ApiResponse<object>> Handle(SignupRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<object> response;
            if (request is null)
            {
                response = new ApiResponse<object>()
                {
                    Status = System.Net.HttpStatusCode.BadRequest,
                    Message = Resources.ErrorResponsesES.BAD_REQUEST,
                    Data = default
                };
                return Task.FromResult(response);
            }

            var phone = new Phone(request.Indivative, request.Phone);
            var document = new Document(request.DocumentType, request.Document);
            var traveler = new Traveler(request.Name, request.LastName, request.Birth, phone, document, request.Gender, request.Email, request.Password);

            _travelRepository.Add(traveler);
            _unitOfWork.Commit();

            response = new ApiResponse<object>()
            {
                Status = System.Net.HttpStatusCode.OK,
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Data = default
            };
            return Task.FromResult(response);
        }
    }
}
