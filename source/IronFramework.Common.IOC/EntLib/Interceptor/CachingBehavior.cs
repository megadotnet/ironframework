
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CachingCallHandlerAttribute.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The caching call handler attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Common.IOC.EntLib.Interceptor
{
    using Microsoft.Practices.Unity.InterceptionExtension;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.Caching;
    using System.Text;

    public class CachingBehavior : IInterceptionBehavior
    {
        /// <summary>
        /// The key guid.
        /// </summary>
        private readonly Guid KeyGuid = new Guid("ECFD1B0F-0CBA-4AA1-89A0-179B636381CA");

        /// <summary>
        /// The expiration time.
        /// </summary>
        private readonly TimeSpan expirationTime = new TimeSpan(0, 5, 0);

        private string methodName;

        /// <summary>
        /// Initializes a new instance of the <see cref="CachingBehavior"/> class.
        /// </summary>
        public CachingBehavior()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CachingBehavior"/> class.
        /// </summary>
        /// <param name="hours">The hours.</param>
        /// <param name="minutes">The minutes.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="_methodName">Name of the _method.</param>
        public CachingBehavior(int hours, int minutes, int seconds,string _methodName)
        {
            this.expirationTime = new TimeSpan(hours, minutes, seconds);
            this.methodName = _methodName;
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
            //match specific method
            if (input.MethodBase.Name != this.methodName)
            {
                return getNext()(input, getNext);
            }

            if (this.targetMethodReturnsVoid(input))
            {
                return getNext()(input, getNext);
            }

            var inputs = new object[input.Inputs.Count];

            for (int i = 0; i < inputs.Length; ++i)
            {
                inputs[i] = input.Inputs[i];
            }

            string cacheKey = this.createCacheKey(input.MethodBase, inputs);
            ObjectCache cache = MemoryCache.Default;
            var cachedResult = (Object[])cache.Get(cacheKey);

            if (cachedResult == null)
            {
                IMethodReturn realReturn = getNext()(input, getNext);

                if (realReturn.Exception == null)
                {
                    this.addToCache(cacheKey, realReturn.ReturnValue);
                }

                return realReturn;
            }

            IMethodReturn cachedReturn = input.CreateMethodReturn(cachedResult[0], input.Arguments);

            return cachedReturn;
        }

        #region Methods

        /// <summary>
        /// The add to cache.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        private void addToCache(string key, object value)
        {
            ObjectCache cache = MemoryCache.Default;
            var cacheValue = new[] { value };
            cache.Add(key, cacheValue, DateTime.Now + this.expirationTime);
        }

        /// <summary>
        /// The create cache key.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="inputs">
        /// The inputs.
        /// </param>
        /// <returns>
        /// The create cache key.
        /// </returns>
        private string createCacheKey(MethodBase method, params object[] inputs)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0}:", Process.GetCurrentProcess().Id);
            sb.AppendFormat("{0}:", this.KeyGuid);

            if (method.DeclaringType != null)
            {
                sb.Append(method.DeclaringType.FullName);
            }

            sb.Append(':');
            sb.Append(method);

            if (inputs != null)
            {
                foreach (object input in inputs)
                {
                    sb.Append(':');

                    if (input != null)
                    {
                        sb.Append(input.ToString());
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// The target method returns void.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The target method returns void.
        /// </returns>
        private bool targetMethodReturnsVoid(IMethodInvocation input)
        {
            var targetMethod = input.MethodBase as MethodInfo;
            return (targetMethod != null) && (targetMethod.ReturnType == typeof(void));
        }

        #endregion

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
            get { return true; }
        }
    }

}