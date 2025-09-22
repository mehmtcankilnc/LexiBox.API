using LexiBox.API.Entities;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace LexiBox.API.Extensions;

public static class GlobalExceptionHandlingExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(config =>
        {
            config.Run(async context =>
            {
                var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = feature?.Error;

                Log.Error(exception, "Unhandled exception occurred at {Path}", feature?.Path);

                var error = new Error(
                    false,
                    "Server.Unexpected",
                    "An unexpected error occurred!"
                );

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(error);
            });
        });

        return app;
    }
}
