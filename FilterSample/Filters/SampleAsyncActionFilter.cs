using FilterSample.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterSample.Filters
{
    public class SampleAsyncActionFilter : ActionFilterAttribute
    {
        // 这时候就没有前后概念
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // action执行前做些什么
            var resultContext = await next();
            // 在action执行后执行某些操作; 将设置resultContext.Result
        }
    }
}
