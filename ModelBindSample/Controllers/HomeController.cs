using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBindSample.Models;

namespace ModelBindSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/products/x",Name ="Test")]
        public IActionResult Privacy()
        {
            var x = Url.RouteUrl("T");
            var z = Url.Action("Test");
            var q = Url.Action("Test2", new { id = 2 });
            return View();
        }

        [HttpGet("/products/pp",Name ="T")]
        public IActionResult Test()
        {
            return Content("x");
        }

        [HttpGet("/products/{id}", Name = "TT")]
        public IActionResult Test2(int id)
        {
            return Content("x");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
