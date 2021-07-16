using TestWorkForMaxima.Domain.Interfaces;

namespace TestWorkForMaxima.Domain.Services
{
    public class Multiply : IArithmeticOperation
    {
        public double Execute(double one, double two)
        {
            return one * two;
        }
    }
}
