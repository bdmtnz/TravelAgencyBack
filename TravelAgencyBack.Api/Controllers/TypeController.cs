using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyBack.Application.Base;

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

        [HttpGet("Authentication", Name = "Authentication")]
        public async Task<ActionResult<ApiResponse<AuthenticationResponse>>> GetAuthentication()
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }

        [HttpGet("Signup", Name = "Signup")]
        public async Task<ActionResult<ApiResponse<object>>> Signup()
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }
    }
}