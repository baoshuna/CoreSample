using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CacheSample.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using CSRedis;
using StackExchange.Redis;
using CacheSample.Extensions;
using Newtonsoft.Json;

namespace CacheSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        private readonly IDistributedCache _redisCache;

        public HomeController(IMemoryCache memoryCache, IDistributedCache redisCache)
        {
            _memoryCache = memoryCache;
            _redisCache = redisCache;
        }

        [ActionName("m")]
        public IActionResult GetCurrentTimeForMemoryCache()
        {
            var time = _memoryCache.Get<DateTime?>("time");

            if (time == null)
            {
                time = DateTime.Now;
                _memoryCache.Set("time", time, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(1)
                });
            }

            return Content(time.ToString());
        }

        /// <summary>实现自带的IDistributedCache的Redis</summary>
        public IActionResult GetCurrentTimeForRedisCache()
        {
            var watch = new Stopwatch();
            watch.Start();

            var time = _redisCache.GetString("redisTime");

            if (time == null)
            {
                time = DateTime.Now.ToString();
                _redisCache.SetString("redisTime", time, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20) });
            }

            watch.Stop();

            return Content($"{time},耗时:{watch.ElapsedMilliseconds}毫秒");
        }

        /// <summary>CsRedis</summary>
        public IActionResult GetCurrentTimeForCsRedisCache()
        {
            using (var csredis = new CSRedisClient("47.100.220.174:6379,password=redis@pwd"))
            {
                var list = csredis.Get<List<string>>("x");
            }

            var watch = new Stopwatch();
            watch.Start();

            watch.Stop();

            return Content($"{watch.ToString()},耗时:{watch.ElapsedMilliseconds}毫秒");
        }

        public IActionResult GetDataByHttpCache(int param)

        {
            var data = new List<int>
            {
                param
            };

            for (int i = 0; i < 100; i++)
            {
                data.Add(i * 78);
            }

            var dataStr = JsonConvert.SerializeObject(data);

            return Content(dataStr);
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