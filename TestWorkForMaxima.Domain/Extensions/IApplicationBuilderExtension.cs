using Microsoft.AspNetCore.Builder;
using System;

namespace TestWorkForMaxima.Domain.Extensions
{
    public static class IApplicationBuilderExtension
    {
        public static IApplicationBuilder UseCustomConcurrencyLimiter(this IApplicationBuilder app)
        {
            if (app is null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<CustomConcurrencyLimiterMiddleware>();
        }
    }
}
