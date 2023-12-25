using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;

namespace TravelAgencyBack.Application.BookingHandler.Switch
{
    public class SwitchBookingRequest : IRequest<ApiResponse<object>>
    {
        public string Id { get; set; }
        public bool Enabled { get; set; }
    }
}
