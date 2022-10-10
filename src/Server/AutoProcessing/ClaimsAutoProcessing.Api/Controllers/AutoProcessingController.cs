using ClaimsAutoProcessing.Api.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsAutoProcessing.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoProcessingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AutoProcessingController> _logger;

        public AutoProcessingController(
            IMediator mediator,
            ILogger<AutoProcessingController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> StartProcessing(int batchId)
        {
            var result = await _mediator.Send(new StartAutoVettingCommand(batchId));

            return Ok();
        }
    }
}