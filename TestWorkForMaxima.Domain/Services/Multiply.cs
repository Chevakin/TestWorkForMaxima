using TestWorkForMaxima.Domain.Interfaces;
using TestWorkForMaxima.Domain.Models;

namespace TestWorkForMaxima.Domain.Services
{
    public class Multiply : IArithmeticOperation
    {
        public bool CanBeApplied(Operations operation)
        {
            return operation == Operations.Multiply;
        }

        public double Execute(double one, double two)
        {
            return one * two;
        }
    }
}
