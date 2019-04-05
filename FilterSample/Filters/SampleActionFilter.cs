using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FilterSample.Filters
{
    public class SampleActionFilter : IActionFilter
    {
        Stopwatch x = default;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            x.Stop();
            var xx = x.ElapsedMilliseconds;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            x.Start();
        }
    }
}
