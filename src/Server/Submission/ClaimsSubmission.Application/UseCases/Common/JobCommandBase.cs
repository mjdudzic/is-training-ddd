using System.Text.Json.Serialization;
using Hangfire.Server;
using MediatR;

namespace ClaimsSubmission.Application.UseCases.Common;

public abstract class JobCommandBase : IRequest
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public PerformContext PerformContext { get; set; }
}