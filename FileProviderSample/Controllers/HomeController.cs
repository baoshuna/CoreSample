using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FileProviderSample.Models;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using System.Text;

namespace FileProviderSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileProvider _fileProvider;
        public HomeController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public IActionResult Index()
        {
            var fileInfo = _fileProvider.GetFileInfo("/Files/subFiles.css");
            using (var stream = fileInfo.CreateReadStream())
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                var fileString = Encoding.Default.GetString(buffer);

                return Content(fileString);
            } 
            //var contents = _fileProvider.GetDirectoryContents(String.Empty);
            //var fileInfo = _fileProvider.GetFileInfo("wwwroot/js");
            //var file2 = (IDirectoryContents)fileInfo;
            //var x = file2.GetDirectoryContents(String.Empty)

            // return View();
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
