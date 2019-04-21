using DockerSampe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DockerSampe.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int x = 111111111;
            if (x == 1)
            {
            }
            return View();
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