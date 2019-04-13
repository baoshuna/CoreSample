using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryForTest
{
    public class PrimeService
    {
        public bool IsPrime(int id)
        {
            if (id == 1)
            {
                return false;
            }

            throw new NotImplementedException("Please create a prime first");
        }
    }
}
