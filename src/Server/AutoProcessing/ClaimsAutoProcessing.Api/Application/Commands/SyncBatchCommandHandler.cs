using ClaimsAutoProcessing.Api.Domain;
using ClaimsAutoProcessing.Api.Infrastructure.Persistence;
using MediatR;

namespace ClaimsAutoProcessing.Api.Application.Commands;

public class SyncBatchCommandHandler : IRequestHandler<SyncBatchCommand, int>
{
    private readonly ClaimsAutoProcessingContext _context;

    public SyncBatchCommandHandler(ClaimsAutoProcessingContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(SyncBatchCommand request, CancellationToken cancellationToken)
    {
        var batch = new Batch
        {
            CreatedAt = DateTime.UtcNow,
            HealthcareFacilityCode = Guid.NewGuid().ToString(),
            Claims = new List<BatchClaim>
            {
                new()
                {
                    DiagnosisCode = "XYZ001A",
                    PatientBirthDate = DateTime.UtcNow,
                    PatientInsuranceNumber = "000001",
                    PatientInsuranceValidity = true,
                    OriginalAmount = 1000
                },
                new()
                {
                    DiagnosisCode = "XYZ001C",
                    PatientBirthDate = DateTime.UtcNow,
                    PatientInsuranceNumber = "000002",
                    PatientInsuranceValidity = true,
                    OriginalAmount = 850
                },
                new()
                {
                    DiagnosisCode = "ANT002A",
                    PatientBirthDate = DateTime.UtcNow,
                    PatientInsuranceNumber = "000003",
                    PatientInsuranceValidity = true,
                    OriginalAmount = 987
                },
                new()
                {
                    DiagnosisCode = "ANT003A",
                    PatientBirthDate = DateTime.UtcNow,
                    PatientInsuranceNumber = "000004",
                    PatientInsuranceValidity = true,
                    OriginalAmount = 2000
                },
                new()
                {
                    DiagnosisCode = "XYZ004A",
                    PatientBirthDate = DateTime.UtcNow,
                    PatientInsuranceNumber = "000005",
                    PatientInsuranceValidity = true,
                    OriginalAmount = 2000
                },
                new(){
                    DiagnosisCode = "XYZ005A",
                    PatientBirthDate = DateTime.UtcNow,
                    PatientInsuranceNumber = "000006",
                    PatientInsuranceValidity = true,
                    OriginalAmount = 50
                }
            }
        };
        _context.Batches.Add(batch);

        await _context.SaveChangesAsync(cancellationToken);

        return batch.Id;
    }
}