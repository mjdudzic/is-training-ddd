using ClaimsAutoProcessing.Api.Application.Services;

namespace ClaimsAutoProcessing.Api.Domain;

public interface IInsuranceValidationService
{
    Task<InsuranceValidationResult> IsValid(BatchClaim claim);
}