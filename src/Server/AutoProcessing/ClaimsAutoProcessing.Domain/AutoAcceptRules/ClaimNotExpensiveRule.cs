namespace ClaimsAutoProcessing.Domain.AutoAcceptRules;

public class ClaimNotExpensiveRule : IAutoAcceptRule
{
    public Task<bool> Check(BatchClaim batchClaim)
    {
        return Task.FromResult(batchClaim.FinalAmount <= 100);
    }
}
