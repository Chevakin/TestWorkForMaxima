using System;
using System.Collections.Generic;
using TestWorkForMaxima.Domain.Interfaces;
using TestWorkForMaxima.Domain.Models;

namespace TestWorkForMaxima.Domain.Services
{
    public class ArithmeicOperationFactory
    {
        private readonly Dictionary<Operations, Type> _operations = new();

        private readonly IServiceProvider _serviceProvider;

        public ArithmeicOperationFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            FillDictionary();
        }

        private void FillDictionary()
        {
            _operations.Add(Operations.Sum, typeof(Sum));
            _operations.Add(Operations.Multiply, typeof(Multiply));
        }

        public IArithmeticOperation GetArithmeticOperation(Operations operation)
        {
            if (_operations.TryGetValue(operation, out Type serviceType))
            {
                var service = _serviceProvider.GetService(serviceType);

                if (service is null)
                {
                    throw new Exception($"класс {serviceType.FullName} не зарегистрирован в DI-контейнере");
                }

                return service as IArithmeticOperation;
            }

            throw new ArgumentException("Данная операция не зарегистрирована в фабрике", nameof(operation));
        }
    }
}
