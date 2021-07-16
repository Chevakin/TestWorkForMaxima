using TestWorkForMaxima.Domain.Interfaces;

namespace TestWorkForMaxima.Domain.Services
{
    public class Sum : IArithmeticOperation
    {
        public double Execute(double one, double two)
        {
            return one + two;
        }
    }
}
