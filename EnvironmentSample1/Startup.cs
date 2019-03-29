using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EnvironmentSample1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnvironmentSample1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("CustomerJson.json");
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<WindowOptions>("window1", Configuration.GetSection("window1"));
            services.Configure<WindowOptions>("window2", Configuration.GetSection("window2"));
            services.PostConfigure<WindowOptions>("window1", options =>
            {
                options.Length = "Post修改";
            });

            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvcWithDefaultRoute();
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("current environment is Production");
            //});
        }

        #region 基于方法的约定
        //public void ConfigureDevelopmentServices(IServiceCollection services)
        //{
        //    services.Configure<CookiePolicyOptions>(options =>
        //    {
        //        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        //        options.CheckConsentNeeded = context => true;
        //        options.MinimumSameSitePolicy = SameSiteMode.None;
        //    });


        //    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        //}

        //public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsProduction())
        //    {
        //        var x = 1;
        //    }
        //    if (env.IsStaging())
        //    {
        //        var x = 1;
        //    }
        //    if (env.IsDevelopment())
        //    {
        //        var x = 1;
        //    }

        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("current environment is Development");
        //    });
        //}
        #endregion
    }
}
