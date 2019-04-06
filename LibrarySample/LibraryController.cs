using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySample
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            return Content("This is LibrartController");
        }
    }
}
