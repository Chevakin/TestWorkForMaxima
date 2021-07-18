using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using TestWorkForMaxima.Domain.Middlewares;

namespace TestWorkForMaxima.Domain
{
    public class CustomConcurrencyLimiterMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IConcurrencyLimiter _limiter;

        public CustomConcurrencyLimiterMiddleware(RequestDelegate next, IConcurrencyLimiter limiter)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _limiter = limiter ?? throw new ArgumentNullException(nameof(limiter));
        }

        public async Task Invoke(HttpContext context)
        {
            var canGO = await _limiter.TryGo();

            if (canGO)
            {
                try
                {
                    await _next(context);
                }
                finally
                {
                    _limiter.ReleaseOne();
                }
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
            }
        }
    }
}
