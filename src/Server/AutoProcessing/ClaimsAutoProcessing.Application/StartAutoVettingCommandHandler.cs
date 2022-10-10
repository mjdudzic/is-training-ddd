using MediatR;

namespace ClaimsAutoProcessing.Application;

public class StartAutoVettingCommandHandler : IRequestHandler<StartAutoVettingCommand>
{
    public StartAutoVettingCommandHandler(ClaimsA)
    {
    }

    public async Task<Unit> Handle(StartAutoVettingCommand request, CancellationToken cancellationToken)
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