using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebHostSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region 通用主机Host的配置
            //var host = new HostBuilder()
            //    .ConfigureAppConfiguration((hostingContext, config) =>
            //    {

            //    })
            //    .ConfigureServices((context, service) =>
            //    {
            //    })
            //    .ConfigureLogging(builder =>
            //    {
            //    })
            //    .UseContentRoot("");
            //host.Build().Run();
            #endregion

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
