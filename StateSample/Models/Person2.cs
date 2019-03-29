using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateSample.Models
{
    public class Person2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address2 Address { get; set; }
    }

    public class Address2
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
    }
}
