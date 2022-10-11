using ClaimsVetting.Domain.SeedWork;
using ClaimsVetting.Domain.SharedKernel;
using MediatR;

namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate;

public class Medicine : Entity<int>
{
    private List<MedicineCorrection> _corrections = new();

    public string Code { get; internal set; }
    public Price TotalPrice { get; internal set; }

    public bool Correct(
        string newCode, 
        decimal newAmount, 
        Gender patientGender,
        ICurrentDateTime currentDateTime,
        ICurrentUser currentUser)
    {
        if (TotalPrice.Amount < newAmount)
            return false;

        _corrections.Add(new MedicineCorrection
        {
            OriginalCode = Code,
            NewCode = newCode,
            OriginalTotalPrice = TotalPrice,
            NewTotalPrice = TotalPrice with { Amount = newAmount },
            CreatedAt = currentDateTime.UtcNow,
            CreatedBy = currentUser.UserId
        });

        Code = newCode;
        TotalPrice = TotalPrice with { Amount = newAmount };

        return true;
    }

    public override void ApplyEvent(INotification @event)
    {
    }
}