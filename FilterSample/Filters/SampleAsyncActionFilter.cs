using FilterSample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterSample.Filters
{
    public class SampleAsyncActionFilter : ActionFilterAttribute
    {
        private readonly IDateTimeService _dateTimeService;
        public SampleAsyncActionFilter(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }
        // 这时候就没有前后概念
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.Result = new ViewResult { ViewName = "Error" };
            if (string.IsNullOrEmpty(""))
            {
                var resultContext = await next();
            }
            // 在action执行后执行某些操作; 将设置resultContext.Result
        }
    }
}
