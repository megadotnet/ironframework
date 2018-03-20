using IronFramework.Common.Logging.Logger;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronFramework.Common.IOC.EntLib.EntLib.CallHandler
{
    /// <summary>
    /// The exception logger call handler.
    /// </summary>
    internal class ExceptionLoggerCallHandler : ICallHandler
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger = new Logger(typeof(ExceptionLoggerCallHandler));

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The invoke.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <param name="getNext">
        /// The get next.
        /// </param>
        /// <returns>
        /// The <see cref="IMethodReturn"/>.
        /// </returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn result = getNext()(input, getNext);
            if (result.Exception != null)
            {
                this.logger.Debug("Exception occured: " + result.Exception.Message);

                this.logger.Debug("Parameters:");
                foreach (var parameter in input.Arguments)
                {
                    Console.WriteLine(parameter.ToString());
                }

                this.logger.Debug("StackTrace:");
                this.logger.Debug(Environment.StackTrace);
            }

            return result;
        }
    }
}
