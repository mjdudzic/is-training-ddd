using ClaimsSubmission.Application.UseCases.Common;
using MediatR;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.EventHandlers.BatchFileAggregate.CodesVerificationResultSaved;

public class FeedbackGenerationJob : JobBase<GenerateFeedbackCommand>
{
    public FeedbackGenerationJob(IMediator mediator) : base(mediator)
    {
    }
}