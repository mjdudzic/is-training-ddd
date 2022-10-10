using ClaimsVetting.Domain.AggregateModels.ClaimAggregate.Events;
using ClaimsVetting.Domain.SeedWork;
using ClaimsVetting.Domain.SharedKernel;

namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate;

public class Claim : AggregateRoot<ClaimId>
{
    internal VettingStatus _status;
    internal string? _vettedBy;
    internal DateTime? _vettedAt;
    internal string? _lockedBy;
    internal DateTime? _lockedAt;

    internal Patient _patient;
    internal Diagnosis _diagnosis;
    internal List<Medicine> _medicines;

    internal Claim()
    {
        Id = new ClaimId(Guid.NewGuid());
        _status = VettingStatus.None;
    }

    public void LockForVetting(
        ICurrentUser currentUser,
        ICurrentDateTime currentDateTime)
    {
        if (_status != VettingStatus.None)
            throw new ClaimAggregateException("Claim has been already vetted");

        if (_lockedBy is not null)
            throw new ClaimAggregateException("Claim has been already locked");

        _lockedBy = currentUser.UserId;
        _lockedAt = currentDateTime.UtcNow;

        AddDomainEvent(new ClaimLockedForVetting(Id));
    }

    public void Accept(
        ICurrentUser claimOfficer,
        ICurrentDateTime currentDateTime)
    {
        if (_status != VettingStatus.None)
            throw new ClaimAggregateException("Claim has been already vetted");

        if (_lockedBy != claimOfficer.UserId)
            throw new ClaimAggregateException("Claim is locked by other user");

        SetVettingStatus(VettingStatus.Accepted, claimOfficer, currentDateTime);

        AddDomainEvent(new ClaimAccepted(Id));
    }

    public void Reject(
        ICurrentUser claimOfficer,
        ICurrentDateTime currentDateTime)
    {
        if (_status != VettingStatus.None)
            throw new ClaimAggregateException("Claim has been already vetted");

        if (_lockedBy != claimOfficer.UserId)
            throw new ClaimAggregateException("Claim is locked by other user");

        SetVettingStatus(VettingStatus.Rejected, claimOfficer, currentDateTime);

        AddDomainEvent(new ClaimRejected(Id));
    }

    public void CorrectDiagnosis(string code, ICurrentDateTime currentDateTime, ICurrentUser currentUser)
    {
        if (_status != VettingStatus.None)
            throw new ClaimAggregateException("Claim has been already vetted");

        if (_diagnosis.Correct(code, _patient.IsChild(currentDateTime), _patient.Gender, currentDateTime, currentUser) == false)
            throw new ClaimAggregateException("Diagnosis cannot be changed");

        AddDomainEvent(new ClaimDiagnosisCorrected(Id));
    }

    public void CorrectMedicine(int medicineId, string code, decimal amount, ICurrentDateTime currentDateTime, ICurrentUser currentUser)
    {
        if (_status != VettingStatus.None)
            throw new ClaimAggregateException("Claim has been already vetted");

        var medicine = _medicines.FirstOrDefault(m => m.Id == medicineId);
        if (medicine is null)
            throw new ClaimAggregateException("Medicine not found");

        if (medicine.Correct(code, amount, _patient.Gender, currentDateTime, currentUser) == false)
            throw new ClaimAggregateException("Diagnosis cannot be changed");

        AddDomainEvent(new ClaimMedicineCorrected(Id, medicine.Id));
    }

    public void LockForReview(
        ICurrentUser currentUser,
        ICurrentDateTime currentDateTime)
    {
        if (_status == VettingStatus.None)
            throw new ClaimAggregateException("Claim has not been vetted yet");

        if (_lockedBy is not null)
            throw new ClaimAggregateException("Claim has been already locked");

        _lockedBy = currentUser.UserId;
        _lockedAt = currentDateTime.UtcNow;

        AddDomainEvent(new ClaimLockedForReview(Id));
    }

    public void MoveBackForReVetting(
        ICurrentUser supervisor,
        ICurrentDateTime currentDateTime)
    {
        if (_status == VettingStatus.None)
            throw new ClaimAggregateException("Claim has not been vetted yet");

        if (_lockedBy != supervisor.UserId)
            throw new ClaimAggregateException("Claim is locked by other user");

        SetVettingStatus(VettingStatus.None, supervisor, currentDateTime);

        AddDomainEvent(new ClaimMovedBackForReVetting(Id));
    }

    private void SetVettingStatus(
        VettingStatus status, 
        ICurrentUser claimOfficer, 
        ICurrentDateTime currentDateTime)
    {
        _status = status;
        _vettedBy = claimOfficer.UserId;
        _vettedAt = currentDateTime.UtcNow;
    }
}