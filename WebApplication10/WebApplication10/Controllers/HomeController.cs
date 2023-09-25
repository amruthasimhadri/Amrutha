using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using WebApplication10.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult post(Customer customer)
        {
            SqlConnection con = new SqlConnection("Data Source = ASIMHADR - L - 5515\SQLEXPRESS; Initial Catalog = Ammu; User ID = sa; Password = Welcome2evoke@1234");
            con.Open(); 
            SqlCommand cmd = new SqlCommand("insert into cus values(customer.Id,customer.Name,customer.Salary",con);
            cmd.ExecuteNonQuery();
            return View(customer);

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