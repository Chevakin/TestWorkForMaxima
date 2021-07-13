using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkForMaxima.Domain.Services.Interfaces
{
    public interface ICalculatorService
    {
        double Sum(double one, double two);

        double Multiply(double one, double two);
    }
}
