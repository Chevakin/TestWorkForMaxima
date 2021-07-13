using TestWorkForMaxima.Domain.Services.Interfaces;

namespace TestWorkForMaxima.Domain.Services
{
    public class CalculatorService : ICalculatorService
    {
        public double Sum(double one, double two)
        {
            return one + two;
        }

        public double Multiply(double one, double two)
        {
            return one * two;
        }
    }
}
