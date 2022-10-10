using Hangfire.Console;
using MediatR;

namespace ClaimsSubmission.Application.UseCases.Common;

public abstract class JobCommandHandlerBase<T> : IRequestHandler<T> where T : JobCommandBase
{
    private T _request;

    public virtual Task<Unit> Handle(T command, CancellationToken cancellationToken)
    {
        _request = command;

        return Task.FromResult(Unit.Value);
    }

    protected void LogInfo(string message) =>
        _request.PerformContext.WriteLine(message);

    protected void LogWarning(string message) =>
        _request.PerformContext.WriteLine(ConsoleTextColor.DarkYellow, message);
}