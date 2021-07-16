using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TestWorkForMaxima.Domain.Interfaces;
using TestWorkForMaxima.Domain.Services;

namespace TestWorkForMaxima.Domain.Extensions
{
    public static class IServiceCollectionExtention
    {
        public static IServiceCollection AddArithmeticOperations(this IServiceCollection services)
        {
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
    }
}
