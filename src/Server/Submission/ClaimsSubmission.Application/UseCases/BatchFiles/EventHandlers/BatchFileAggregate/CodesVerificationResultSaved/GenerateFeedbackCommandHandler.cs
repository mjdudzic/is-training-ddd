using ClaimsSubmission.Application.UseCases.Common;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using MediatR;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.EventHandlers.BatchFileAggregate.CodesVerificationResultSaved;

public class GenerateFeedbackCommandHandler : JobCommandHandlerBase<GenerateFeedbackCommand>
{
    private readonly IRepository _repository;

    public GenerateFeedbackCommandHandler(
        IRepository repository)
    {
        _repository = repository;
    }

    public override async Task<Unit> Handle(GenerateFeedbackCommand command, CancellationToken cancellationToken)
    {
        await base.Handle(command, cancellationToken);

        LogInfo($"Generating feedback file for {command.BatchFileId.Value}");

        var batchFile = await _repository.Get(command.BatchFileId);

        if (batchFile is null)
        {
            LogWarning($"Batch file {command.BatchFileId.Value} does not exist");
            return Unit.Value;
        }

        batchFile.GenerateFeedback();

        await _repository.SaveChanges(cancellationToken);

        return Unit.Value;
    }
}