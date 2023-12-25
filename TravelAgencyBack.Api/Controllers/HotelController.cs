using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelagencyBack.Application.Base;
using TravelagencyBack.Application.HotelHanlder.Add;
using TravelagencyBack.Application.HotelHanlder.Filter;
using TravelagencyBack.Application.Switch;
using TravelAgencyBack.Domain;

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

        [HttpPost("Filter", Name = "GetHotels")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Hotel>>>> GetHotels(FilterRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }

        [HttpPost(Name = "ManageHotel")]
        public async Task<ActionResult<ApiResponse<object>>> ManageHotel(ManageRequest request)
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