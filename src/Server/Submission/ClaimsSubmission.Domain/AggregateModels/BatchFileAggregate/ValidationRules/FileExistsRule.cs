namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.ValidationRules;

public class FileExistsRule : IBatchFileValidationRule
{
    private readonly IFileStorageService _fileStorageService;

    public FileExistsRule(IFileStorageService fileStorageService)
    {
        _fileStorageService = fileStorageService;
    }

    public int Order => 1;

    public async Task<RuleValidationResult> IsValid(BatchFile batchFile)
    {
        var fileExists = await _fileStorageService
            .FileExists(
                Path.Combine(
                    batchFile.HealthcareFacilityId.AccreditationCode,
                    batchFile.FileInternalName));

        return new RuleValidationResult(
            fileExists,
            fileExists
                ? null
                : "File does not exist");
    }
}