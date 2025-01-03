using Microsoft.AspNetCore.Mvc;
using MTBS.Infrastructure.MockData.MockRepos;
using MTBS.WebApp.Models;
using System.Diagnostics;

namespace MTBS.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MockTable _table;

        public HomeController(ILogger<HomeController> logger, MockTable table)
        {
            _logger = logger;
            _table = table;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return Redirect("/Swagger");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
