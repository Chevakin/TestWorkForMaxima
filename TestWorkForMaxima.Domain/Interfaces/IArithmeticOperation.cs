using TestWorkForMaxima.Domain.Models;

namespace TestWorkForMaxima.Domain.Interfaces
{
    public interface IArithmeticOperation
    {
        double Execute(double one, double two);

        bool CanBeApplied(Operations operation);
    }
}
