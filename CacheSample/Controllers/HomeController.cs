using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CacheSample.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CacheSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public HomeController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult GetCurrentTimeForMemoryCache()
        {
            var time = _memoryCache.Get<DateTime?>("time");

            if (time == null)
            {
                time = DateTime.Now;
                _memoryCache.Set("time", time, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now
                });
            }

            return Content(time.ToString());
        }

        #region

        public IActionResult Index()
        {
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

        #endregion
    }
}