using TestWorkForMaxima.Domain.Interfaces;
using TestWorkForMaxima.Domain.Models;

namespace TestWorkForMaxima.Domain.Services
{
    public class Sum : IArithmeticOperation
    {
        public bool CanBeApplied(Operations operation)
        {
            return operation == Operations.Sum;
        }

        public double Execute(double one, double two)
        {
            return one + two;
        }
    }
}
