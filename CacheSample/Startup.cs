using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace CacheSample
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
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            // 内存缓存
            services.AddMemoryCache();

            // 分布式缓存
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("AliyunRedis");
                options.InstanceName = "AliyunRedis";
            });

            // 中间件缓存
            services.AddResponseCaching();

            // 响应压缩
            services.AddResponseCompression();

            services.AddMvc(options =>
            {
                // Http缓存的配置
                options.CacheProfiles.Add("myProfile", new CacheProfile
                {
                    Duration = 600,
                    Location = ResponseCacheLocation.Any
                });
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // 响应压缩
            app.UseResponseCompression();

            // 中间件缓存
            app.UseResponseCaching();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // 静态文件Http缓存
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromMinutes(20)
                    };
                }
            });
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=GetCurrentTimeForRedisCache}/{id?}");
            });
        }
    }
}