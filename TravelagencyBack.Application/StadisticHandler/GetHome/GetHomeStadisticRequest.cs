using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;

namespace TravelAgencyBack.Application.StadisticHandler.GetHome
{
    public class GetHomeStadisticRequest : IRequest<ApiResponse<List<GetHomeStadisticResponse>>>
    {
    }
}
