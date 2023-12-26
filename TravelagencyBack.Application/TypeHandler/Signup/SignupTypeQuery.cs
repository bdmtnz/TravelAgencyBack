using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Application.TypeHandler.Signup
{
    public class SignupTypeRequest : IRequest<ApiResponse<SignupTypeResponse>>
    {
        public SignupTypeRequest() { }
    }

    public class SignupTypeQuery : IRequestHandler<SignupTypeRequest, ApiResponse<SignupTypeResponse>>
    {
        public Task<ApiResponse<SignupTypeResponse>> Handle(SignupTypeRequest request, CancellationToken cancellationToken)
        {
            var types = new SignupTypeResponse()
            {
                DocumentTypes = new List<EnumResponse<DocumentType>>()
                {
                    new EnumResponse<DocumentType>(DocumentType.CC),
                    new EnumResponse<DocumentType>(DocumentType.TI),
                    new EnumResponse<DocumentType>(DocumentType.NUIP),
                    new EnumResponse<DocumentType>(DocumentType.PP),
                    new EnumResponse<DocumentType>(DocumentType.EXT)
                },
                Genders = new List<EnumResponse<Gender>>()
                {
                    new EnumResponse<Gender>(Gender.Female),
                    new EnumResponse<Gender>(Gender.Male),
                    new EnumResponse<Gender>(Gender.Other)
                }
            };

            var response = new ApiResponse<SignupTypeResponse>()
            {
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Status = System.Net.HttpStatusCode.OK,
                Data = types
            };
            return Task.FromResult(response);
        }
    }
}
