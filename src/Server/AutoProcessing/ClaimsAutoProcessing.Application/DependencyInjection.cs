using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ClaimsAutoProcessing.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddClaimsAutoProcessingApplication(this IServiceCollection services)
        => services
            .AddMediatR(Assembly.GetExecutingAssembly());

}