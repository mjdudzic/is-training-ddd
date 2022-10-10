using Hangfire.Server;
using MediatR;

namespace ClaimsSubmission.Application.UseCases.Common;

public abstract class JobBase<T> where T : JobCommandBase, IRequest
{
    protected readonly IMediator Mediator;

    protected JobBase(IMediator mediator)
    {
        Mediator = mediator;
    }

    public async Task Execute(T command, PerformContext context)
    {
        command.PerformContext = context;
        try
        {
            await ExecuteCommand(command);
        }
        catch (Exception e)
        {
            throw;
        }
    }

    protected virtual Task ExecuteCommand(T command) => Mediator.Send(command);
}