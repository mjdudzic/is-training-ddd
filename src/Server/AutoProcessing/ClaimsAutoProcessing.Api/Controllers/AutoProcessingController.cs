using ClaimsAutoProcessing.Api.Application.Commands;
using ClaimsAutoProcessing.Api.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAutoProcessing.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoProcessingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ClaimsAutoProcessingContext _context;
        private readonly ILogger<AutoProcessingController> _logger;

        public AutoProcessingController(
            IMediator mediator,
            ClaimsAutoProcessingContext context,
            ILogger<AutoProcessingController> logger)
        {
            _mediator = mediator;
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> StartProcessing()
        {
            var batchId = await _mediator.Send(new SyncBatchCommand());
            await _mediator.Send(new StartAutoVettingCommand(batchId));

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Batches.Include(b => b.Claims).ToListAsync());
        }
    }
}