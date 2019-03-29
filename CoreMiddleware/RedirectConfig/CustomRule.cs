using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMiddleware.RedirectConfig
{
    public class CustomRule : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            var request = context.HttpContext.Request;

            if (request.Path.StartsWithSegments(new PathString("/xmlfile")))
            {
                return;
            }

            if (request.Path.Value.EndsWith(".xml", StringComparison.InvariantCultureIgnoreCase))
            {
                var response = context.HttpContext.Response;
                response.StatusCode = StatusCodes.Status301MovedPermanently;
                context.Result = RuleResult.EndResponse;
                response.Headers[HeaderNames.Location] = "/xmlfile" + request.Path + request.QueryString;
            }
        }
    }
}
