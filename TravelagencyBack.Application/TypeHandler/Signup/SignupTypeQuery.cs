using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;

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
            throw new NotImplementedException();
        }
    }
}
