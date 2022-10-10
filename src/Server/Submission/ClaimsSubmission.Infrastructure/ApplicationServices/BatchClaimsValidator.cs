using System.Text.Json;
using ClaimsSubmission.Application.UseCases.BatchFiles.Services;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using ClaimsSubmission.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace ClaimsSubmission.Infrastructure.ApplicationServices;

public class BatchClaimsValidator : IBatchClaimsValidator
{
    private readonly IOptions<BatchFileStorageConfiguration> _options;

    private readonly Dictionary<string, string> _codeErrors = new()
    {
        { "ABC-001", "Code format invalid" },
        { "ABC-002", "Code has already expired" }
    };

    public BatchClaimsValidator(IOptions<BatchFileStorageConfiguration> options)
    {
        _options = options;
    }

    public async Task<BatchClaimsVerificationResult> ValidateCodes(string relativeFilePath, CancellationToken cancellationToken)
    {
        var fullFilePath = Path.Combine(_options.Value.RootPath, relativeFilePath);
        var fileContent = await File.ReadAllTextAsync(fullFilePath, cancellationToken);

        var batchClaims = JsonSerializer.Deserialize<BatchClaims>(fileContent);
        
        var codesToValidate = batchClaims.Claims
            .Select(c => c.ServiceCode)
            .Distinct()
            .ToList();

        /* Request to external API */
        var apiResult = new List<CodeValidationResult>();

        codesToValidate.ForEach(code =>
        {
            if (_codeErrors.ContainsKey(code))
                apiResult.Add(new CodeValidationResult(code, _codeErrors[code]));
        });
        /****************************/

        /* ACL */
        var claimCodeVerificationResults = new List<ClaimCodeVerificationResult>();

        foreach (var codeValidationResult in apiResult)
        {
            batchClaims.Claims
                .Where(c => c.ServiceCode == codeValidationResult.Code)
                .ToList()
                .ForEach(c => claimCodeVerificationResults.Add(
                    new ClaimCodeVerificationResult(c.ClaimNumber, c.ServiceCode, codeValidationResult.Error)));
        }

        return new BatchClaimsVerificationResult(batchClaims.Claims.Count, claimCodeVerificationResults);
    }
}

public record CodeValidationResult(string Code, string Error);

public record BatchClaims(IReadOnlyCollection<BatchClaim> Claims);

public record BatchClaim(string ClaimNumber, string ServiceCode);