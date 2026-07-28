using Dashboard.WebApi;

namespace Dashboard.WebApp;

public static class DependencyInjections
{
    public static WebApplicationBuilder AddWebApp(this WebApplicationBuilder builder)
    {
        // Services
        builder.Services.AddWebApi();
        builder.Services.AddRazorPages();

        return builder;
    }
    public static WebApplication UseWebApp(this WebApplication app)
    {
        // Middleware
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        else
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dashboard API V1");
                c.RoutePrefix = "swagger";
            });
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        // Endpoints
        app.MapControllers();
        app.MapRazorPages();
        return app;
    }
}
