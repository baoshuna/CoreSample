using FilterSample.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace FilterSample.Filters
{
    public class AddHeaderWithFactoryAttribute : Attribute, IFilterFactory
    {
        public bool IsReusable => false;

        // Implement IFilterFactory
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new InternalAddHeaderFilter(serviceProvider);
        }
        private class InternalAddHeaderFilter : ResultFilterAttribute
        {
            private readonly IServiceProvider _serviceProvider;
            public InternalAddHeaderFilter(IServiceProvider serviceProvider)
            {
                _serviceProvider = serviceProvider;
            }

            public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
            {
                var dateTimeService = _serviceProvider.GetService<IDateTimeService>();
                var time = dateTimeService.GetCurrentTime();

                context.HttpContext.Response.Headers.Add(
                    "Internal", new string[] { "Header Added" });

                await next();
            }
        }

    }
}
