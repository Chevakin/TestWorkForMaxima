using Microsoft.Extensions.Configuration;

namespace TestWorkForMaxima.Domain.Extensions
{
    public static class IConfigurationExtention
    {
        public static int GetMaxConcurrentRequest(this IConfiguration configuration)
        {
            return int.Parse(configuration["MaxConcurrentRequest"]);
        }
    }
}
