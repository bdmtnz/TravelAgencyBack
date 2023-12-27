using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Application.HotelHandler.Switch;
using TravelAgencyBack.Application.Hotelhandler.Add;
using TravelAgencyBack.Application.Hotelhandler.Filter;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Application.HotelHandler.GetById;

namespace TravelAgencyBack.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private readonly IMediator _mediator;

        public HotelController(ILogger<HotelController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("ById/{HotelId}", Name = "GetHotelById")]
        public async Task<ActionResult<ApiResponse<Hotel>>> GetHotels(string HotelId)
        {
            var handled = await _mediator.Send(new GetHotelByIdRequest(HotelId));
            return Ok(handled);
        }

        [HttpPost("Filter", Name = "GetHotels")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Hotel>>>> GetHotels(FilterHotelRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }

        [HttpPost(Name = "ManageHotel")]
        public async Task<ActionResult<ApiResponse<object>>> ManageHotel(ManageHotelRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }

        [HttpPut(Name = "SwitchHotel")]
        public async Task<ActionResult<ApiResponse<object>>> SwitchHotel(SwitchHotelRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }
    }
}