namespace ClaimsAutoProcessing.Api.Application.Services;

public record TariffCorrectionResult(int ClaimId, string Code, decimal ValidPrice);