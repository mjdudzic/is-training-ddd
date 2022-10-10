using ClaimsSubmission.Application.UseCases.Common;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;

namespace ClaimsSubmission.Application.UseCases.CodesValidation.Commands;

public class ValidateCodesCommand : JobCommandBase
{
    public BatchFileId BatchFileId { get; init; }

    public string FilePath { get; set; }
}