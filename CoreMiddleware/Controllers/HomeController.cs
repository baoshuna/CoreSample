using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreMiddleware.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var x = "Home=>Index";
            return Content(x);
        }
    }
}