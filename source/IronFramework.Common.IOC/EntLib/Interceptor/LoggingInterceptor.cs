namespace IronFramework.Common.IOC.EntLib.Interceptor
{
    using IronFramework.Common.Logging.Logger;
    using Microsoft.Practices.Unity.InterceptionExtension;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// LoggingInterceptor
    /// </summary>
    public class LoggingInterceptor : IInterceptionBehavior
    {

        /// <summary>
        /// The log
        /// </summary>
        private ILogger log = new Logger("LoggingInterceptor");

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            /* Call the method that was intercepted */
            string className = input.MethodBase.DeclaringType.Name;
            string methodName = input.MethodBase.Name;
            string generic = input.MethodBase.DeclaringType.IsGenericType ? string.Format("<{0}>", input.MethodBase.DeclaringType.GetGenericArguments().ToStringList()) : string.Empty;
            string arguments = input.Arguments.ToStringList();

            string preMethodMessage = string.Format("{0}{1}.{2}({3})", className, generic, methodName, arguments);
            this.log.Debug("PreMethodCalling: " + preMethodMessage);
            //Logging
            this.log.Debug(preMethodMessage);
            //Invoke method
            IMethodReturn msg = null;
        
            msg = getNext()(input, getNext);
            //loggin exception
            if (msg.Exception != null)
            {
                this.log.Error(msg.Exception);
            }

            //Post method calling
            string postMethodMessage = string.Format("{0}{1}.{2}() -> {3}", className, generic, methodName, msg.ReturnValue);
            this.log.Debug("PostMethodCalling: " + postMethodMessage);
            //Logging
            this.log.Debug(postMethodMessage);
            return msg;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }

    public static class EnumerableExtensions
    {
        public static string ToStringList(this IEnumerable list)
        {
            var sb = new StringBuilder();

            foreach (var item in list)
            {
                sb.AppendFormat("{0}, ", item);
            }
            if (sb.Length > 0)
                sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }
    }

}
