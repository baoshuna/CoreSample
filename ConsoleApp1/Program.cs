using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Test());
        }

        static int Test()
        {
            try
            {
                return 1;
            }
            catch
            {
                return 2;
            }
            finally
            {
                return 3;
            }
        }
    }
}
