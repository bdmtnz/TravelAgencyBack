using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Application.TypeHandler.Room;
using TravelAgencyBack.Application.TypeHandler.Signup;

namespace TravelAgencyBack.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeController : ControllerBase
    {
        private readonly ILogger<TypeController> _logger;
        private readonly IMediator _mediator;

        public TypeController(ILogger<TypeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("Room", Name = "RoomTypes")]
        public async Task<ActionResult<ApiResponse<RoomTypeResponse>>> GetRoomTypes()
        {
            var handled = await _mediator.Send(new RoomTypeRequest());
            return Ok(handled);
        }

        [HttpGet("Signup", Name = "SignupTypes")]
        public async Task<ActionResult<ApiResponse<SignupTypeResponse>>> GetSignupTypes()
        {
            var handled = await _mediator.Send(new SignupTypeRequest());
            return Ok(handled);
        }
    }
}