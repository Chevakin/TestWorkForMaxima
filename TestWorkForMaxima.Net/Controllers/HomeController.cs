using Microsoft.AspNetCore.Mvc;

namespace TestWorkForMaxima.Net.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
