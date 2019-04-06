using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationPartSample.Controllers
{
    public class HelloTest
    {
        public IActionResult Index()
        {
            return new ContentResult() { Content = Guid.NewGuid().ToString() };
        }
    }
}
