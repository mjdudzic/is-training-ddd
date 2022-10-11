namespace ClaimsAutoProcessing.Domain;

public record TariffCorrectionResult(int ClaimId, string Code, decimal ValidPrice);