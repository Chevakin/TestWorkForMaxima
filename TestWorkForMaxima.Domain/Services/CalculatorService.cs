using System;
using TestWorkForMaxima.Domain.Models;
using TestWorkForMaxima.Domain.Services.Interfaces;

namespace TestWorkForMaxima.Domain.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ArithmeicOperationFactory _factory;

        public CalculatorService(ArithmeicOperationFactory factory)
        {
            _factory = factory;
        }

        public double Calculate(double one, double two, Operations operation)
        {
            var arithmeticOperation = _factory.GetArithmeticOperation(operation);

            if (arithmeticOperation is null)
            {
                throw new Exception($"Не удалось получить из фабрики операция сопоставимую с {nameof(operation)}");
            }

            return arithmeticOperation.Execute(one, two);
        }
    }
}
