using IronFramework.Common.Logging.Logger;
using System;

namespace Common.Logging.NLog.StandardConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger("Program");
            logger.Debug("test with .net core app");
        }
    }
}
