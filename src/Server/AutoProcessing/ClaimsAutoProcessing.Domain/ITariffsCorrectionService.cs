namespace ClaimsAutoProcessing.Domain;

public interface ITariffsCorrectionService
{
    Task<TariffCorrectionResult> CorrectTariffs(BatchClaim batchClaim);
}