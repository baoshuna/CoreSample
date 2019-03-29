using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreLogging.Models;
using Microsoft.Extensions.Logging;
using CoreLogging.Extensions;
using Microsoft.AspNetCore.Http;

namespace CoreLogging.Controllers
{
    public class HomeController : Controller
    {
        // 方法一,维度很小，灵活度差
        private readonly ILogger<HomeController> _logger;

        // 方法二,灵活度高
        //private readonly ILoggerFactory _loggerFactory;

        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }
        public IActionResult Index()
        {
            // int x = 1, y = 0;
            // var z = x / y;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int code)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Notfound()
        {
            return View();
        }
    }
}
