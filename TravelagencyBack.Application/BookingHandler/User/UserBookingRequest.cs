using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;

namespace TravelAgencyBack.Application.BookingHandler.User
{
    public class UserBookingRequest : IRequest<ApiResponse<IEnumerable<Booking>>>
    {
        [Required]
        public string TravelerId { get; set; }

        public UserBookingRequest()
        {
            
        }

        public UserBookingRequest(string travelerId)
        {
            TravelerId = travelerId;
        }
    }
}
