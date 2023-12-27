using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;

namespace TravelAgencyBack.Application.BookingHandler.GetById
{
    public class GetBookingByIdRequest : IRequest<ApiResponse<Booking>>
    {
        [Required]
        public string Id { get; set; }
    }
}
