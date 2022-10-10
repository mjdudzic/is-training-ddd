using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClaimsSubmission.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddClaimsSubmissionApplication(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddMediatR(Assembly.GetExecutingAssembly());

}