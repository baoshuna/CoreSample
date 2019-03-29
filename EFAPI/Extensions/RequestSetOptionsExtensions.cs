using EFAPI.Middleware;
using EFAPI.Model;
using EFAPI.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAPI.Extensions
{
    public static class RequestSetOptionsExtensions
    {
        public static IApplicationBuilder UseRequestSetOptions(this IApplicationBuilder app, AppOptions options = null)
        {
            return app.UseMiddleware<RequestSetOptionsMiddleware>(Options.Create(options));
        }

        public static IServiceCollection AddRequestSetOptions(this IServiceCollection services)
        {
            return services.AddTransient<ITestService, TestService>();
        }
    }
}
