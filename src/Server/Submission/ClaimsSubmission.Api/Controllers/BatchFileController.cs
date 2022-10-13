using ClaimsSubmission.Application.UseCases.BatchFiles.Commands.Submit;
using ClaimsSubmission.Application.UseCases.BatchFiles.Commands.UploadBatchFile;
using ClaimsSubmission.Application.UseCases.BatchFiles.Queries.GetBatchFiles;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsSubmission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchFileController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetBatchFiles()
        {
            var result = await Mediator.Send(new GetBatchFilesQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UploadBatchFile([FromForm] UploadBatchFileDto model)
        {
            var result = await Mediator.Send(
                new UploadBatchFileCommand(new HealthcareFacilityId(model.HealthcareFacilityId), model.File));

            return Accepted();
        }

        [HttpPut("{batchFileId}")]
        public async Task<IActionResult> BatchFile(Guid batchFileId, [FromBody] BatchActionDto model)
        {
            var result = await Mediator.Send(
                new BatchFileActionCommand((BatchFileId)batchFileId, model.BatchFileAction));

            return Ok(result);
        }
    }
}
