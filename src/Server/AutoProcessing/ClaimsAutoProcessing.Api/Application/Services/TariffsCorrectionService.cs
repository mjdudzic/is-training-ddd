using ClaimsAutoProcessing.Api.Domain;

namespace ClaimsAutoProcessing.Api.Application.Services;

public class TariffsCorrectionService
{
    public Task<TariffCorrectionResult> CorrectTariffs(BatchClaim batchClaim)
    {
        return Task.FromResult(
            new TariffCorrectionResult(
                batchClaim.Id, 
                batchClaim.DiagnosisCode, 
                batchClaim.OriginalAmount * 0.9m));
    }
}