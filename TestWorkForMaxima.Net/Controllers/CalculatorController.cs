using Microsoft.AspNetCore.Mvc;
using System;
using TestWorkForMaxima.Domain.Models;
using TestWorkForMaxima.Domain.Services.Interfaces;

namespace TestWorkForMaxima.Net.Controllers
{
    [Route("api/calculator")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculator;

        public CalculatorController(ICalculatorService calculator)
        {
            _calculator = calculator;
        }

        [Route("calculate")]
        [HttpPost]
        public double Calculate(double one, double two, Operations operation)
        {
            return _calculator.Calculate(one, two, operation);
        }
    }
}
