using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;

namespace TravelAgencyBack.Application.Hotelhandler.Filter
{
    public class FilterHotelRequest : IRequest<ApiResponse<IEnumerable<TravelAgencyBack.Domain.Hotel>>>
    {
        public string? Name { get; set; }
        public bool? Enabled { get; set; }
    }
}
