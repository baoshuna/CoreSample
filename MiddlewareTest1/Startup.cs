using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFAPI.Extensions;
using EFAPI.Model;
using EFAPI.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MiddlewareTest1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRequestSetOptions();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseRequestSetOptions(new AppOptions { Format = "t" });


            app.Run(async context =>
            {
                await context.Response.WriteAsync("app.Run\r\n");
            });
        }
    }
}
