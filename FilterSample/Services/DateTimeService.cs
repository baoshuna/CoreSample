using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterSample.Services
{
    public class DateTimeService : IDateTimeService
    {
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString();
        }
    }
}
