using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using ClaimsSubmission.Domain.SharedKernel;
using MediatR;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.Commands.Submit;

public class BatchFileActionCommandHandler : IRequestHandler<BatchFileActionCommand, SubmittedBatchDto>
{
    private readonly IRepository _repository;
    private readonly ICurrentDateTime _currentDateTime;

    public BatchFileActionCommandHandler(
        IRepository repository,
        ICurrentDateTime currentDateTime)
    {
        _repository = repository;
        _currentDateTime = currentDateTime;
    }

    public async Task<SubmittedBatchDto> Handle(BatchFileActionCommand request, CancellationToken cancellationToken)
    {
        var batchFile = await _repository.Get(request.BatchFile);

        batchFile?.Submit(_currentDateTime);

        await _repository.SaveChanges(cancellationToken);

        return new SubmittedBatchDto(
            batchFile.HealthcareFacilityId.AccreditationCode,
            batchFile.Id.Value,
            batchFile.SubmittedAt,
            $"{batchFile.HealthcareFacilityId.AccreditationCode}/{batchFile.Id.Value}/reports");
    }
}