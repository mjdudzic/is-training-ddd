using ClaimsVetting.Domain.SeedWork;
using ClaimsVetting.Domain.SharedKernel;
using MediatR;

namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate;

internal class Diagnosis : Entity<int>
{
    private List<DiagnosisCorrection> _corrections = new();
    public string Code { get; internal set; }

    public bool Correct(
        string newCode, 
        bool patientIsChild, 
        Gender patientGender,
        ICurrentDateTime currentDateTime,
        ICurrentUser currentUser)
    {
        if (newCode.EndsWith("A") && patientIsChild)
            return false;

        if (newCode.EndsWith("C") && patientIsChild)
            return false;

        _corrections.Add(new DiagnosisCorrection
        {
            OriginalCode = Code,
            NewCode = newCode,
            CreatedAt = currentDateTime.UtcNow,
            CreatedBy = currentUser.UserId
        });

        Code = newCode;

        return true;
    }

    public override void ApplyEvent(INotification @event)
    {
    }
}