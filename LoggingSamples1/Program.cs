using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;

namespace LoggingSamples1
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            //loggerFactory.AddProvider(new ConsoleLoggerProvider(new Test()));
            ILogger logger = loggerFactory.CreateLogger<Program>();
            loggerFactory.AddNLog();

            while (true)
            {
                logger.LogTrace("this is LogTrace", DateTime.Now.ToString());
                logger.LogDebug("this is LogDebug", DateTime.Now.ToString());
                logger.LogInformation("this is LogInformation", DateTime.Now.ToString());
                logger.LogWarning("this is LogWarning", DateTime.Now.ToString());
                logger.LogError("this is LogError", DateTime.Now.ToString());
                logger.LogCritical("this is LogCritical", DateTime.Now.ToString());
            }


            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
    class Test : IOptionsMonitor<ConsoleLoggerOptions>
    {
        public ConsoleLoggerOptions CurrentValue
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ConsoleLoggerOptions Get(string name)
        {
            throw new NotImplementedException();
        }

        public IDisposable OnChange(Action<ConsoleLoggerOptions, string> listener)
        {
            throw new NotImplementedException();
        }
    }
}
