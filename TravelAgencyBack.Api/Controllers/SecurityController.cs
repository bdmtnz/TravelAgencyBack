using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Application.Security.Authentication;
using TravelAgencyBack.Application.Security.Signup;

namespace TravelAgencyBack.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly ILogger<SecurityController> _logger;
        private readonly IMediator _mediator;

        public SecurityController(ILogger<SecurityController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("Authentication", Name = "Authentication")]
        public async Task<ActionResult<ApiResponse<AuthenticationResponse>>> GetAuthentication(AuthenticationRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }

        [HttpPost("Signup", Name = "Signup")]
        public async Task<ActionResult<ApiResponse<object>>> Signup(SignupRequest request)
        {
            var handled = await _mediator.Send(request);
            return Ok(handled);
        }
    }
}