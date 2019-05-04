using System;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var x = 6 & 11;

            Console.WriteLine(x);
        }

        private static (int, string) Test(int m)
        {
            var x = 1;

            return (x, "x");
        }
    }
}