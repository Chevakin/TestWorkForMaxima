using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using TestWorkForMaxima.Domain.Interfaces;
using TestWorkForMaxima.Domain.Middlewares;
using TestWorkForMaxima.Domain.Services;

namespace TestWorkForMaxima.Domain.Extensions
{
    public static class IServiceCollectionExtention
    {
        public static IServiceCollection AddArithmeticOperations(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSingleton<IEnumerable<IArithmeticOperation>>(p =>
            {
                return new IArithmeticOperation[]
                {
                    new Sum(),
                    new Multiply(),
                };
            });

            return services;
        }

        public static IServiceCollection AddConcurrentRequestOptions(this IServiceCollection services, IConfiguration configuration)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.Configure<ConcurrentRequestOptions>(configuration.GetSection(ConcurrentRequestOptions.ConcurrentRequest));
            services.AddSingleton<IValidateOptions<ConcurrentRequestOptions>, ConcurrencyRequestOptionsValidate>();
            services.AddSingleton<IConcurrencyLimiter, SimpleConcurrencyLimiter>();

            return services;
        }
    }
}
