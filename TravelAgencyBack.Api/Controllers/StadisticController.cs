using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Application.StadisticHandler.GetHome;

namespace TravelAgencyBack.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StadisticController : ControllerBase
    {
        private readonly ILogger<StadisticController> _logger;
        private readonly IMediator _mediator;

        public StadisticController(ILogger<StadisticController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("Home", Name = "GetHomeStadistic")]
        public async Task<ActionResult<ApiResponse<GetHomeStadisticResponse>>> GetHomeStadistic()
        {
            var handled = await _mediator.Send(new GetHomeStadisticRequest());
            return Ok(handled);
        }
    }
}