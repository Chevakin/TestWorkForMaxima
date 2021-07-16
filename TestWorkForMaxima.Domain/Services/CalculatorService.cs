using System;
using System.Collections.Generic;
using System.Linq;
using TestWorkForMaxima.Domain.Interfaces;
using TestWorkForMaxima.Domain.Models;
using TestWorkForMaxima.Domain.Services.Interfaces;

namespace TestWorkForMaxima.Domain.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IEnumerable<IArithmeticOperation> _operations;

        public CalculatorService(IEnumerable<IArithmeticOperation> operations)
        {
            _operations = operations;
        }

        public double Calculate(double one, double two, Operations operation)
        {
            var realOperation = _operations
                .Where(o => o.CanBeApplied(operation));

            if (realOperation.Any() == false)
                throw new Exception($"Нет зарегистрированной в DI-контейнере операции для {nameof(operation)}");

            if (realOperation.Count() > 1)
                throw new Exception($"В DI-контейнере больше одной операции сопоставимой с {nameof(operation)}");

            return realOperation
                .First()
                .Execute(one, two);
        }
    }
}
