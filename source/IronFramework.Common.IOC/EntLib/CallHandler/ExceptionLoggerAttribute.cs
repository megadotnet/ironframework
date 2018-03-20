using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronFramework.Common.IOC.EntLib.EntLib.CallHandler
{
    /// <summary>
    /// The exception logger attribute.
    /// </summary>
    internal class ExceptionLoggerAttribute : HandlerAttribute
    {
        /// <summary>
        /// The create handler.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <returns>
        /// The <see cref="ICallHandler"/>.
        /// </returns>

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new ExceptionLoggerCallHandler();
        }
    }
}
