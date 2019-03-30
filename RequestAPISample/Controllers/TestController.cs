using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refit;
using RequestAPISample.Refit;

namespace RequestAPISample.Controllers
{
    public class TestController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;

        //public TestController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        public async Task<IActionResult> Index([FromServices]IProductClientService productClientService)
        {
            var result = await productClientService.GetProduct();
            //HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "localhost.xxx");
            //message.Headers.Add("key1", "value1");
            //var httpClient = _httpClientFactory.CreateClient();
            //await httpClient.SendAsync(message);

            return Content(result);
        }
    }
}