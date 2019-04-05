using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadSample.Controllers
{
    public class StreamingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}