using ClaimsVetting.Domain.SeedWork;
using ClaimsVetting.Domain.SharedKernel;

namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate;

internal class Patient : Entity<int>
{
    public Patient(string insuranceNumber, DateTime birthDate, Gender gender)
    {
        InsuranceNumber = insuranceNumber;
        BirthDate = birthDate;
        Gender = gender;
    }

    public string InsuranceNumber { get; }
    public DateTime BirthDate { get; }
    public Gender Gender { get; }

    public bool IsChild(ICurrentDateTime currentDateTime) => 
        currentDateTime.UtcNow.Year - BirthDate.Year < 12;
}