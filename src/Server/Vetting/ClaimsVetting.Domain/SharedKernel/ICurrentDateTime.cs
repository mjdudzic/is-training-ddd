namespace ClaimsVetting.Domain.SharedKernel;

public interface ICurrentDateTime
{
    public DateTime UtcNow { get; }
}