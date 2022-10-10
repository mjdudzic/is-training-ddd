using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Events;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Exceptions;
using ClaimsSubmission.Domain.SeedWork;
using ClaimsSubmission.Domain.SharedKernel;

namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;

public class BatchFile : AggregateRoot<BatchFileId>
{
    private readonly HealthcareFacilityId _healthcareFacilityId;
    private readonly string _fileOriginalName;
    private readonly string _fileInternalName;
    private readonly byte[] _fileHash;
    private readonly DateTime _createdAt;
    private bool _isUnique;
    private bool _isSubmittable;
    private BatchFileId? _duplicatedBatchFile;
    private BatchFileValidationResult? _batchFileValidationResult;
    private DateTime? _submittedAt;

    public HealthcareFacilityId HealthcareFacilityId => _healthcareFacilityId;
    public string FileInternalName => _fileInternalName;
    public string FileOriginalName => _fileOriginalName;
    public byte[] FileHash => _fileHash;
    public DateTime CreatedAt => _createdAt;
    public DateTime? SubmittedAt => _submittedAt;
    public bool IsUnique => _isUnique;
    public bool IsSubmittable => _isSubmittable;
    public BatchFileId? DuplicatedBatchFile => _duplicatedBatchFile;
    public BatchFileValidationResult? BatchFileValidationResult => _batchFileValidationResult;

    internal BatchFile()
    {
    }

    public BatchFile(
        HealthcareFacilityId healthcareFacilityId,
        string fileOriginalName,
        string fileInternalName,
        byte[] fileHash,
        ICurrentDateTime currentDateTime)
    {
        _healthcareFacilityId = healthcareFacilityId;
        _fileOriginalName = fileOriginalName;
        _fileInternalName = fileInternalName;
        _fileHash = fileHash;
        _createdAt = currentDateTime.UtcNow;

        Id = new BatchFileId(Guid.NewGuid());
    }

    public async Task Upload(
        IBatchFileValidationService batchFileValidationService)
    {
        var validationResult = await batchFileValidationService.IsValid(this);

        if (validationResult.Success == false)
            throw new BatchFileException(validationResult.FailReason ?? "Something went bad");
        
        AddDomainEvent(new BatchFileUploadedEvent(Id, string.Empty));
    }

    public async Task ValidateUniqueness(IBatchFileDuplicateCheck batchFileDuplicateCheck)
    {
        if (_fileHash is null)
            throw new BatchFileException("File hash not available");

        _duplicatedBatchFile = await batchFileDuplicateCheck.IsDuplicate(this);
        _isUnique = _duplicatedBatchFile is null;

        AddDomainEvent(_isUnique
            ? new UniquenessValidationSucceededEvent(Id)
            : new UniquenessValidationFailedEvent(Id));
    }

    public void SaveValidationResult(
        BatchClaimsVerificationResult batchClaimsVerificationResult,
        ICurrentDateTime currentDateTime)
    {
        if (_isUnique == false)
            throw new BatchFileException("File is a duplicate and cannot be processed further");

        _batchFileValidationResult = new BatchFileValidationResult(Id, batchClaimsVerificationResult, currentDateTime);
        _isSubmittable = (_batchFileValidationResult?.ValidClaimsRatio ?? 0) >= 0.1m;

        AddDomainEvent(new CodesVerificationResultSavedEvent(Id));
    }

    public void GenerateFeedback()
    {
        AddDomainEvent(new FeedbackGeneratedEvent(Id));
    }

    public void Submit(ICurrentDateTime currentDateTime)
    {
        if (_isSubmittable == false)
            throw new BatchFileException("Batch is not submittable at the current moment");

        _submittedAt = currentDateTime.UtcNow;

        AddDomainEvent(new FileSubmittedEvent(Id));
    }
}