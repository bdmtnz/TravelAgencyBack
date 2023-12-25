using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelagencyBack.Application.Base;
using TravelagencyBack.Application.RoomHandler.Add;
using TravelagencyBack.Application.RoomHandler.Filter;
using TravelagencyBack.Application.RoomHandler.Switch;
using TravelAgencyBack.Domain;

namespace TravelAgencyBack.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IMediator _mediator;

        public RoomController(ILogger<RoomController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("Filter", Name = "GetRooms")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Room>>>> GetRooms(FilterRoomRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }

        [HttpPost(Name = "ManageRoom")]
        public async Task<ActionResult<ApiResponse<object>>> ManageRoom(ManageRoomRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }

        [HttpPut(Name = "SwitchRoom")]
        public async Task<ActionResult<ApiResponse<object>>> SwitchRoom(SwitchRoomRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }
    }
}