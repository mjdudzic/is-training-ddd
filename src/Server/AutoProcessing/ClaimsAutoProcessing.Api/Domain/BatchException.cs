namespace ClaimsAutoProcessing.Api.Domain;

public class BatchException : Exception
{
    public BatchException(string msg) : base(msg)
    {
    }
}