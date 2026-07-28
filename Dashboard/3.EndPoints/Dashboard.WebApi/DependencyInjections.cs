using Dashboard.Infrastructure;

namespace Dashboard.WebApi;

public static class DependencyInjections
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddInfrastructure();

        return services;
    }
}
