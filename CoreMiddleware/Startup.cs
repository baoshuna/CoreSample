using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CoreMiddleware.RedirectConfig;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace CoreMiddleware
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (StreamReader iisUrlRewriteStreamReader = File.OpenText("RedirectConfig/IISUrlRewrite.xml"))
            {
                app.UseRewriter(new RewriteOptions()
                .AddIISUrlRewrite(iisUrlRewriteStreamReader)
                .Add(new CustomRule())
                 //.AddRedirectToHttps()
                 //.AddRedirect("file/(.*)", "home/$1", 301)
                 //.AddRewrite(@"^home/(\d+)/(\d+)", "file/index?var1=$1&var2=$2", true)
                 //.AddRedirectToHttps
                 );
            }

            app.UseMvcWithDefaultRoute();
            app.Run(context => context.Response.WriteAsync(
                $"Rewritten or Redirected Url: " +
                $"{context.Request.Path + context.Request.QueryString}"));
        }
    }
}
