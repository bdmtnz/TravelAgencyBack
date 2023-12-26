using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Application.TypeHandler.Signup;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Application.TypeHandler.Room
{
    public class RoomTypeRequest : IRequest<ApiResponse<RoomTypeResponse>>
    {
        public RoomTypeRequest() { }
    }
    public class RoomTypeQuery : IRequestHandler<RoomTypeRequest, ApiResponse<RoomTypeResponse>>
    {
        public Task<ApiResponse<RoomTypeResponse>> Handle(RoomTypeRequest request, CancellationToken cancellationToken)
        {
            var types = new RoomTypeResponse()
            {
                Types = new List<EnumResponse<RoomType>>()
                {
                    new EnumResponse<RoomType>(RoomType.Sencilla),
                    new EnumResponse<RoomType>(RoomType.Matrimonial),
                    new EnumResponse<RoomType>(RoomType.Familiar)
                }
            };

            var response = new ApiResponse<RoomTypeResponse>()
            {
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Status = System.Net.HttpStatusCode.OK,
                Data = types
            };
            return Task.FromResult(response);
        }
    }
}
