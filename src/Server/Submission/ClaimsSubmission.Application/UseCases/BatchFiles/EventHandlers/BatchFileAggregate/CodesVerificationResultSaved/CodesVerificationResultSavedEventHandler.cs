using ClaimsSubmission.Application.UseCases.CodesValidation.Events.CodesVerified;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Events;
using Hangfire;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.EventHandlers.BatchFileAggregate.CodesVerificationResultSaved;

public class CodesVerificationResultSavedEventHandler : INotificationHandler<CodesVerifiedEvent>
{
    private readonly ILogger<CodesVerificationResultSavedEventHandler> _logger;
    private readonly IRepository _repository;
    private readonly IBackgroundJobClient _backgroundJobClient;

    public CodesVerificationResultSavedEventHandler(
        ILogger<CodesVerificationResultSavedEventHandler> logger,
        IRepository repository,
        IBackgroundJobClient backgroundJobClient)
    {
        _logger = logger;
        _repository = repository;
        _backgroundJobClient = backgroundJobClient;
    }

    public async Task Handle(CodesVerifiedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("@{BatchFile} codes verification saved", notification);

        //var batchFile = await _repository.Get(notification.Id);

        //batchFile?.EnableSubmission();

        _backgroundJobClient.Enqueue<FeedbackGenerationJob>(
            job => job.Execute(new GenerateFeedbackCommand
            {
                BatchFileId = notification.Id
            }, null));

        //await _repository.SaveChanges(cancellationToken);
    }
}