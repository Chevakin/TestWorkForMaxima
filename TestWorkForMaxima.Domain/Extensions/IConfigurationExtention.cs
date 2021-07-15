using Microsoft.Extensions.Configuration;
using System;

namespace TestWorkForMaxima.Domain.Extensions
{
    public static class IConfigurationExtention
    {
        public static int GetMaxConcurrentRequest(this IConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return int.Parse(configuration["MaxConcurrentRequest"]);
        }
    }
}
