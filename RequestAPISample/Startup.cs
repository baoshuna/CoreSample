using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Refit;
using RequestAPISample.CustomerHandlers;
using RequestAPISample.Refit;
using RequestAPISample.Service;

namespace RequestAPISample
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
            //services.AddHttpClient("github", c =>
            //{
            //    // 提供一个Base的地址
            //    c.BaseAddress = new Uri("https://api.github.com/");
            //    // Github API versioning
            //    c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            //    // Github requires a user-agent
            //    c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            //})
            //.AddTypedClient(client => RestService.For<IProductClientService>("https://api.xcode.me"));

            var timeout = Policy.TimeoutAsync<HttpResponseMessage>(
                             TimeSpan.FromSeconds(10));
            var longTimeout = Policy.TimeoutAsync<HttpResponseMessage>(
                                TimeSpan.FromSeconds(30));
            var policy = services.AddPolicyRegistry();
            policy.Add("regular", timeout);
            policy.Add("long", longTimeout);

            services.AddHttpClient("regulartimeouthandler")
                .AddPolicyHandlerFromRegistry("regular");

            services.AddTransient<ValidateHeaderHandler>();
            services
                .AddRefitClient<IProductClientService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://www.xcode.me"))
                .AddHttpMessageHandler<ValidateHeaderHandler>()
                .AddTransientHttpErrorPolicy(p =>
                    p.WaitAndRetryAsync(3, a => TimeSpan.FromMilliseconds(600)));

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                    template: "{controller=Test}/{action=Index}/{id?}");
            });
        }
    }
}
