using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySample
{
    public class LibraryTest
    {
        public IActionResult Index()
        {
            return new ContentResult { Content = "hello from LibraryTest1" };
        }
    }
}
