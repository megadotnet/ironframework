namespace IronFramework.Common.IOC.EntLib.Interceptor
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using Microsoft.Practices.Unity.InterceptionExtension;
    using IronFramework.Common.Logging.Logger;

    /// <summary>
    /// PerformanceInterceptor
    /// </summary>
    public class PerformanceInterceptor : IInterceptionBehavior
    {
        /// <summary>
        /// The log
        /// </summary>
        private static readonly ILogger log = new Logger("PerformanceInterceptor");

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceInterceptor"/> class.
        /// </summary>
        public PerformanceInterceptor()
        {
        }

        /// <summary>
        /// Returns the interfaces required by the behavior for the objects it intercepts.
        /// </summary>
        /// <returns>
        /// The required interfaces.
        /// </returns>
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        /// <summary>
        /// Implement this method to execute your behavior processing.
        /// </summary>
        /// <param name="input">Inputs to the current call to the target.</param>
        /// <param name="getNext">Delegate to execute to get the next delegate in the behavior chain.</param>
        /// <returns>
        /// Return value from the target.
        /// </returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            string className = input.MethodBase.DeclaringType.Name;
            string methodName = input.MethodBase.Name;

            IMethodReturn msg = null;

            //Pre method calling
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
           
            // Method is invoked
            msg = getNext()(input, getNext);

            //Post method calling
            stopwatch.Stop();
            log.DebugFormat("{2}－{1}Time elapsed: {0} TotalSeconds", stopwatch.Elapsed.TotalSeconds, methodName, className);
            return msg;
        }

        /// <summary>
        /// Returns a flag indicating if this behavior will actually do anything when invoked.
        /// </summary>
        /// <remarks>
        /// This is used to optimize interception. If the behaviors won't actually
        /// do anything (for example, PIAB where no policies match) then the interception
        /// mechanism can be skipped completely.
        /// </remarks>
        public bool WillExecute
        {
            get
            {
                return true;
            }

        }
    }
}
