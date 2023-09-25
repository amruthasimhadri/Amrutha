using delg.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace delg.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SalaryPlan _plan;

        public HomeController(ILogger<HomeController> logger)
        {
            _plan = new SalaryPlan();
            _logger = logger;
        }

        public IActionResult Index()
        {
            _plan.salary = 3000M;
            _plan.fun1 = func;
            return View();
        }
        private decimal func()
        {
            return 1000M;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}