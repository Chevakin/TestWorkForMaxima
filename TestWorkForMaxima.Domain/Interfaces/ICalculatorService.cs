using TestWorkForMaxima.Domain.Models;

namespace TestWorkForMaxima.Domain.Services.Interfaces
{
    public interface ICalculatorService
    {
        double Calculate(double one, double two, Operations operation);
    }
}
