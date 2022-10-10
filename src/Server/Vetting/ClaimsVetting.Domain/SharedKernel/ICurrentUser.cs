namespace ClaimsVetting.Domain.SharedKernel;

public interface ICurrentUser
{
    string UserName { get; }
    string UserId { get; }
}