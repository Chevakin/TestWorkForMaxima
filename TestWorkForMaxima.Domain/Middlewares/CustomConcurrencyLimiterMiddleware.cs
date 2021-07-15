using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TestWorkForMaxima.Domain
{
    public class CustomConcurrencyLimiterMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly int _maxConcurrentRequest;

        private readonly SemaphoreSlim _semaphore;

        private int _countRequests;

        public CustomConcurrencyLimiterMiddleware(RequestDelegate next, int maxConcurrentRequest)
        {
            _next = next;
            _maxConcurrentRequest = maxConcurrentRequest;

            _semaphore = new SemaphoreSlim(maxConcurrentRequest);
        }

        public async Task Invoke(HttpContext context)
        {
            int countRequests = Interlocked.Increment(ref _countRequests);

            if (countRequests > _maxConcurrentRequest)
            {
                Interlocked.Decrement(ref _countRequests);

                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
            }
            else
            {
                await _semaphore.WaitAsync();

                try
                {
                    await _next(context);
                }
                finally
                {
                    _semaphore.Release();

                    Interlocked.Decrement(ref _countRequests);
                }
            }
        }
    }
}
