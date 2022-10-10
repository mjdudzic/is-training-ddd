using ClaimsSubmission.Application.UseCases.Common;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.EventHandlers.BatchFileAggregate.CodesVerificationResultSaved;

public class GenerateFeedbackCommand : JobCommandBase
{
    public BatchFileId BatchFileId { get; init; }
}