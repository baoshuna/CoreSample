using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAPI.Service
{
    public class TestService : ITestService
    {
        private readonly string guid = Guid.NewGuid().ToString();
        public string GetGuid()
        {
            return this.guid;
        }
    }
}
