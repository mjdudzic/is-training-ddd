using ClaimsAutoProcessing.Api.Domain;

namespace ClaimsAutoProcessing.Api.Application.Services.AutoAcceptRules;

public interface IAutoAcceptRule
{
    Task<bool> Check(BatchClaim batchClaim);
}