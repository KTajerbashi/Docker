using Dashboard.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Dashboard.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {

        services.AddApplication();
        return services;
    }
}
