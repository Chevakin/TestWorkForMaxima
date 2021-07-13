using Microsoft.AspNetCore.Mvc;
using System;
using TestWorkForMaxima.Domain.Models;
using TestWorkForMaxima.Domain.Services.Interfaces;

namespace TestWorkForMaxima.Net.Controllers
{
    [Route("")]
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculator;

        public CalculatorController(ICalculatorService calculator)
        {
            _calculator = calculator;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }

        [Route("calculate")]
        [HttpGet]
        public double Calculate(double one, double two, Operations operation)
        {
            Func<double, double, double> func;

            if (operation == Operations.Sum)
            {
                func = _calculator.Sum;
            }
            else if (operation == Operations.Multiply)
            {
                func = _calculator.Multiply;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(operation));
            }

            return func(one, two);
        }
    }
}
