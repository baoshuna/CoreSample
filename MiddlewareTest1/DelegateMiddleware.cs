using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareTest1
{
    public class DelegateMiddleware
    {
        public Task DelegateMiddleware1(HttpContext context, Func<Task> next)
        {
            context.Response.WriteAsync("RRR\r\n");

            return next.Invoke();
        }
    }
}
