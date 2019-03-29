using EFAPI.Model;
using EFAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EFAPI.Middleware
{
    /// <summary>
    /// 自定义的中间件
    /// </summary>
    public class RequestSetOptionsMiddleware
    {
        //这个委托用于调用下一个中间件
        private readonly RequestDelegate next;

        //传进来的参数
        private readonly IOptions<AppOptions> options;
        private readonly ITestService testService;

        public RequestSetOptionsMiddleware(RequestDelegate next, IOptions<AppOptions> options, ITestService testService)
        {
            this.next = next;
            this.options = options;
            this.testService = testService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            // xcode.me?option=xxx
            var datetime = DateTime.Now.ToString(this.options.Value.Format);
            await httpContext.Response.WriteAsync(datetime + "\r\n");
            await httpContext.Response.WriteAsync(testService.GetGuid() + "\r\n");

            //直接调用下一个中间件
            await next(httpContext);
        }
    }
}
