using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;

namespace TravelAgencyBack.Application.BookingHandler.Filter
{
    public class FilterBookingRequest : IRequest<ApiResponse<IEnumerable<Booking>>>
    {
        public string? HotelId { get; set; }
        public string? RoomId { get; set; }
        public string? TravelerId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool? Enabled { get; set; }
    }
}
