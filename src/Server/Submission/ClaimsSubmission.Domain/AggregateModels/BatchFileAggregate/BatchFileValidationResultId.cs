namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;

public record BatchFileValidationResultId
{
    public Guid Value { get; }

    public BatchFileValidationResultId(Guid value)
    {
        Value = value;
    }
        
    public static implicit operator Guid(BatchFileValidationResultId id)
        => id.Value;
        
    public static implicit operator BatchFileValidationResultId(Guid id)
        => new(id);
}