using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelagencyBack.Application.Base;

namespace TravelagencyBack.Application.BookingHandler.Manage
{
    public class ManageBookingCommand : IRequestHandler<ManageBookingRequest, ApiResponse<object>>
    {
        public Task<ApiResponse<object>> Handle(ManageBookingRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
