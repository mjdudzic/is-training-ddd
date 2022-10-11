using ClaimsAutoProcessing.Api.Domain;

namespace ClaimsAutoProcessing.Api.Application.Services.AutoAcceptRules;

public class AntenatalDiagnosisMeetsPriceRangeRule : IAutoAcceptRule
{
    public Task<bool> Check(BatchClaim batchClaim)
    {
        return Task.FromResult(
            batchClaim.DiagnosisCode.StartsWith("ANT") &&
            batchClaim.FinalAmount is > 800 and <= 1000);
    }
}
