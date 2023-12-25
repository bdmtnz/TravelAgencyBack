using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Application.BookingHandler.Filter;
using TravelAgencyBack.Application.BookingHandler.Manage;
using TravelAgencyBack.Application.BookingHandler.Switch;
using TravelAgencyBack.Domain;

namespace TravelAgencyBack.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IMediator _mediator;

        public BookingController(ILogger<BookingController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("Filter", Name = "GetBookings")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Booking>>>> GetBookings(FilterBookingRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }

        [HttpPost(Name = "ManageBooking")]
        public async Task<ActionResult<ApiResponse<object>>> ManageBooking(ManageBookingRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }

        [HttpPut(Name = "SwitchBooking")]
        public async Task<ActionResult<ApiResponse<object>>> SwitchBooking(SwitchBookingRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }
    }
}