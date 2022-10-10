namespace ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Exceptions;

public class BatchFileException : Exception
{
    public BatchFileException(string message) : base(message)
    {
    }
}