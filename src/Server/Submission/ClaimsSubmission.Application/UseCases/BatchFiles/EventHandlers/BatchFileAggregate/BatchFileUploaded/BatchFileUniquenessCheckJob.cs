using ClaimsSubmission.Application.UseCases.Common;
using MediatR;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.EventHandlers.BatchFileAggregate.BatchFileUploaded;

public class BatchFileUniquenessCheckJob : JobBase<ValidateFileUniquenessCommand>
{
    public BatchFileUniquenessCheckJob(IMediator mediator) : base(mediator)
    {
    }
}