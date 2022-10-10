using System.Reflection;
using MediatR;

namespace ClaimsAutoProcessing.Api.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddClaimsAutoProcessingApplication(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddMediatR(Assembly.GetExecutingAssembly());

}