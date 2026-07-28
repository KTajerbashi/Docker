using Dashboard.Infrastructure;

namespace Dashboard.WebApi;

public static class DependencyInjections
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services.AddControllers()
            .AddApplicationPart(typeof(DependencyInjections).Assembly);

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddProblemDetails(); // پاسخ استاندارد خطا برای API (RFC 7807)

        services.AddInfrastructure();

        return services;
    }
}