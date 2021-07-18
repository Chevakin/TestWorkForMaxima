using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestWorkForMaxima.Domain.Extensions;

namespace TestWorkForMaxima.Domain.Middlewares
{
    public class SimpleConcurrencyLimiter : IConcurrencyLimiter
    {
        private readonly IOptionsMonitor<ConcurrentRequestOptions> _options;

        private int _countCurrentRequests = 0;

        public SimpleConcurrencyLimiter(IOptionsMonitor<ConcurrentRequestOptions> options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void ReleaseOne()
        {
            Interlocked.Decrement(ref _countCurrentRequests);
        }

        public Task<bool> TryGo()
        {
            var countRequests = Interlocked.Increment(ref _countCurrentRequests);
            bool result;

            if (countRequests > _options.CurrentValue.Max)
            {
                Interlocked.Decrement(ref _countCurrentRequests);

                result = false;
            }
            else
            {
                result = true;
            }

            return new ValueTask<bool>(result).AsTask();
        }
    }
}
