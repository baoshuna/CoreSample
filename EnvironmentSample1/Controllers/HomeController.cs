using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentSample1.Models;
using Microsoft.Extensions.Options;

namespace EnvironmentSample1.Controllers
{
    public class HomeController : Controller
    {
        private readonly WindowOptions _windowConfig1;

        private readonly WindowOptions _windowConfig2;

        public HomeController(IOptionsSnapshot<WindowOptions> options)
        {
            this._windowConfig1 = options.Get("window1");
            this._windowConfig2 = options.Get("window2");
        }
        public IActionResult Index()
        {
            //ConfigureNamedOptions
            var x = _windowConfig1;
            var y = _windowConfig2;
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
