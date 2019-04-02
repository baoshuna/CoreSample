using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignalRChatRoomSample.Hubs;
using SignalRChatRoomSample.Services;

namespace SignalRChatRoomSample
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

            // http://localhost:62841
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:62841")
                .AllowCredentials();
            }));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(config =>
                {
                    config.LoginPath = "/User/Login";
                    config.ReturnUrlParameter = "returnUrl";
                });

            services.AddSignalR(options=>
            {
                options.EnableDetailedErrors = true;
            }).AddMessagePackProtocol();
            services.AddSingleton<IUserIdProvider, NameUserIdProvider>();
            services.AddTransient<IUserService, UserService>();

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

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseSignalR(builder =>
            {
                builder.MapHub<ChatHub>("/chathub",options=>
                {
                    options.Transports = HttpTransportType.LongPolling;
                    options.LongPolling.PollTimeout = TimeSpan.FromSeconds(1);
                });
                builder.MapHub<GroupChatHub>("/groupChatHub");
                builder.MapHub<UserChatHub>("/userChatHub");
                builder.MapHub<StreamHub>("/streamHub");
            });

            app.Use(async (context, next) =>
            {
                var hubContext = context.RequestServices
                                        .GetRequiredService<IHubContext<ChatHub>>();
                await hubContext.Clients.All.SendAsync("ReceiveMessage", "Admin", "欢迎进入聊天室" + "---" + DateTime.Now.ToString());
                await next();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=User}/{action=Index}/{id?}");
            });
        }
    }
}
