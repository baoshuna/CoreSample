using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;

namespace RequestAPISample.Refit
{
    public interface IProductClientService
    {
        [Get("/api/products")]
        Task<string> GetProduct();
    }
}
