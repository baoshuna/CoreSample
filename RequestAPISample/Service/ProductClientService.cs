using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RequestAPISample.Service
{
    public class ProductClientService
    {
        public HttpClient Client { get; set; }

        public ProductClientService(HttpClient client)
        {
            client.BaseAddress = new Uri("http://www.xcode.me");
            // API的版本号
            client.DefaultRequestHeaders.Add("Accept","application/vnd.github.v3+json");
            // Api需要的密钥
            client.DefaultRequestHeaders.Add("User-Agent","HttpClientFactory-Sample");

            Client = client;
        }

        public async Task<IEnumerable<string>> GetProducts()
        {
            var response = await Client.GetAsync("/product");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<IEnumerable<string>>();

            return result;
        }
    }
}
