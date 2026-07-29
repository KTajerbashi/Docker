using Dashboard.WebApi;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.WebApp;

public static class DependencyInjections
{
    public static WebApplicationBuilder AddWebApp(this WebApplicationBuilder builder)
    {
        builder.Services.AddWebApi();
        builder.Services.AddRazorPages();

        return builder;
    }

    public static WebApplication UseWebApp(this WebApplication app)
    {
        // ----- Exception Handling: شاخه‌بندی بر اساس مسیر -----
        app.UseWhen(
            context => context.Request.Path.StartsWithSegments("/api"),
            apiApp => apiApp.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerFeature>();
                    context.Response.ContentType = "application/problem+json";
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    var problem = new ProblemDetails
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Title = "An unexpected error occurred.",
                        Detail = app.Environment.IsDevelopment() ? feature?.Error.Message : null
                    };

                    await context.Response.WriteAsJsonAsync(problem);
                });
            }));

        app.UseWhen(
            context => !context.Request.Path.StartsWithSegments("/api"),
            webApp =>
            {
                webApp.UseExceptionHandler("/Error");
                webApp.UseStatusCodePagesWithReExecute("/Error/{0}");
            });

        if (!app.Environment.IsDevelopment())
        {
            app.UseHsts();
        }
        else
        {
            
        }
        
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dashboard API V1");
            c.RoutePrefix = "swagger";
        });

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // اگر WebApi توسط کلاینت جداگانه (SPA/Mobile) هم مصرف می‌شود:
        // app.UseCors("DefaultPolicy");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapRazorPages();

        return app;
    }
}