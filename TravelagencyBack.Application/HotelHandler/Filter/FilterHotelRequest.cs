using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelagencyBack.Application.Base;

namespace TravelagencyBack.Application.Hotelhandler.Filter
{
    public class FilterHotelRequest : IRequest<ApiResponse<IEnumerable<TravelAgencyBack.Domain.Hotel>>>
    {
        public string Name { get; set; }
    }
}
