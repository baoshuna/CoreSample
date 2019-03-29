using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CoreMiddleware.Controllers
{
    //[Route("[controller]/[action]")]
    public class FileController : Controller
    {
        public IActionResult Index(string var1,string var2)
        {
            return Content($"this is {nameof(FileController)}/{nameof(Index)} And SubPath = {var2}");
        }

        public IActionResult GetFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", "sample2.zip");

            return PhysicalFile(path, "application/zip", "xxx.zip");//octet-stream
        }
    }
}