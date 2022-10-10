namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;

public record BatchFileId
{
    public Guid Value { get; }

    public BatchFileId(Guid value)
    {
        Value = value;
    }
        
    public static implicit operator Guid(BatchFileId id)
        => id.Value;
        
    public static implicit operator BatchFileId(Guid id)
        => new(id);
}