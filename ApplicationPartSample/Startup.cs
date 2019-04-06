using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ApplicationPartSample.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationPartSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region 方式一
            //var mvcBulider = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //// 把应用程序部件添加到配置中
            //var pluginsDir = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");
            //var plugins = Directory.GetFiles(pluginsDir).Where(it => Path.GetExtension(it).Equals(".dll"));
            //foreach (var plugin in plugins)
            //{
            //    Assembly assembly = Assembly.LoadFile(plugin);
            //    mvcBulider.AddApplicationPart(assembly);
            //}
            #endregion
            #region 方式二
            var pluginsDir = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");
            var plugins = Directory.GetFiles(pluginsDir).Where(it => Path.GetExtension(it).Equals(".dll"));
            services.AddMvc().ConfigureApplicationPartManager(options=>
               {
                    foreach (var plugin in plugins)
                    {
                        Assembly assembly = Assembly.LoadFile(plugin);
                        options.ApplicationParts.Add(new AssemblyPart(assembly));
                    }
                   options.FeatureProviders.Add(new GenericControllerFeatureProvider());
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            #endregion

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
