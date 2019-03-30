using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RequestAPISample.CustomerHandlers
{
    public class ValidateHeaderHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            //if (!request.Headers.Contains("X-API-KEY"))
            //{
            //    return new HttpResponseMessage(HttpStatusCode.BadRequest)
            //    {
            //        Content = new StringContent(
            //            "You must supply an API key header called X-API-KEY")
            //    };
            //}
            var response = await base.SendAsync(request, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.RequestTimeout)
                {
                    Content = new StringContent(
                        "cuowu")
                };
            }
        }
    }
}
