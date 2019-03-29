using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProtoBuf;
using StateSample.Models;

namespace StateSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var index = 0;

            // 总性能毫秒数
            long jsonTotal = 0;
            long protobufTotal = 0;

            // 每次性能集合毫秒数
            var jsonArr = new List<long>();
            var protobufArr = new List<long>();

            // 用于测试数据
            var person1 = new Person1
            {
                Id = 1,
                Name = "Test",
                Address = new Address1
                {
                    Line1 = "line",
                    Line2 = "line"
                }
            };
            var person2 = new Person2
            {
                Id = 1,
                Name = "Test",
                Address = new Address2
                {
                    Line1 = "line",
                    Line2 = "line"
                }
            };
            while (index < 1000)
            {
                // 测试json性能
                Stopwatch watchJson = new Stopwatch();
                watchJson.Start();
                for (int i = 0; i < 100; i++)
                {
                    var str = JsonConvert.SerializeObject(person1);
                    var obj = JsonConvert.DeserializeObject<Person1>(str);
                }
                watchJson.Stop();
                var jsonSpendTime = watchJson.ElapsedMilliseconds;
                jsonTotal += jsonSpendTime;
                jsonArr.Add(jsonSpendTime);

                // 测试protobuf性能1
                Stopwatch watchProtobuf = new Stopwatch();
                watchProtobuf.Start();
                for (int i = 0; i < 100; i++)
                {
                    using (var file = System.IO.File.Create("Person.bin"))
                    {
                        Serializer.Serialize<Person2>(file, person2);
                        var obj = Serializer.Deserialize<Person2>(file);
                    }
                }
                watchProtobuf.Stop();
                var protobufSpendTime = watchProtobuf.ElapsedMilliseconds;
                protobufTotal += protobufSpendTime;
                protobufArr.Add(protobufSpendTime);
            }

            return Content("");
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
