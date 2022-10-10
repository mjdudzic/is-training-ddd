namespace ClaimsAutoProcessing.Domain;

public class BatchClaim
{
    public int Id { get; set; }
    public string PatientInsuranceNumber { get; set; }
    public DateTime PatientBirthDate { get; set; }
    public string DiagnosisCode { get; set; }
    public decimal TotalAmount { get; set; }
}