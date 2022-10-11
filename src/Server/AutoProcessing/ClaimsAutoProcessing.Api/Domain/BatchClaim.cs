namespace ClaimsAutoProcessing.Api.Domain;

public class BatchClaim
{
    public int Id { get; set; }
    public string PatientInsuranceNumber { get; set; }
    public DateTime PatientBirthDate { get; set; }
    public string DiagnosisCode { get; set; }
    public decimal OriginalAmount { get; set; }
    public decimal FinalAmount { get; set; }
    public bool PatientInsuranceValidity { get; set; }
    public VettingStatus VettingStatus { get; set; }
    public bool SelectedForAudit { get; set; }
}