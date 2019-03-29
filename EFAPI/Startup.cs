using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using EFAPI.Filters;
using EFAPI.Middleware;
using EFAPI.Service;
using EFAPI.Extensions;

namespace EFAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //内存数据库UseInMemoryDatabase
            services.AddDbContext<MyDbContext>(it => it.UseSqlServer(Configuration.GetSection("CoreDbString")["ConnectionString"]));

            //依赖注入下文档生成的工具
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1.0" });
            });

            // 将自定义的配置管道注入到容器中
            // 这是个多例的
            //services.AddTransient<IStartupFilter, RequestSetOptionsStartupFilter>();
        }

        // 此方法由RunTime调用. 使用此方法配置HTTP请求管道.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<RequestSetOptionsMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //加入MVC中间件
            app.UseMvc();

            //在管道中加入生成文档的工具
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //加入自定义的中间件
            app.UseRequestSetOptions();
        }
    }
}
