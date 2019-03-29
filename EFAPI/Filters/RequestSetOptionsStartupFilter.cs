using EFAPI.Extensions;
using EFAPI.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAPI.Filters
{
    /// <summary>
    /// 自定义的管道filter
    /// </summary>
    public class RequestSetOptionsStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                // app.UseRequestSetOptions();
                next(app);
            };
        }
    }
}
