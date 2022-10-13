namespace ClaimsAutoProcessing.Api.Domain;

public class BatchClaimException : Exception
{
    public BatchClaimException(string msg) : base(msg)
    {
    }
}