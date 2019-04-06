using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterSample.Filters
{
    public class TestUseDiAttribute: ServiceFilterAttribute//TypeFilterAttribute
    {
        public TestUseDiAttribute():base(typeof(SampleAsyncActionFilter))
        {

        }
    }
}
