// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CachingCallHandlerAttribute.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The caching call handler attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Common.IOC.EntLib.CallHandler
{
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.InterceptionExtension;
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.Caching;
    using System.Text;

    /// <summary>
    /// The caching call handler attribute.
    /// </summary>
    [Serializable]
    [ConfigurationElementType(typeof(CustomCallHandlerData))]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class CachingCallHandlerAttribute : HandlerAttribute, ICallHandler
    {
        #region Constants and Fields

        /// <summary>
        /// The key guid.
        /// </summary>
        private readonly Guid KeyGuid = new Guid("ECFD1B0F-0CBA-4AA1-89A0-179B636381CA");

        /// <summary>
        /// The expiration time.
        /// </summary>
        private readonly TimeSpan expirationTime = new TimeSpan(0, 5, 0);

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CachingCallHandlerAttribute"/> class.
        /// </summary>
        public CachingCallHandlerAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CachingCallHandlerAttribute"/> class.
        /// </summary>
        /// <param name="hours">
        /// The hours.
        /// </param>
        /// <param name="minutes">
        /// The minutes.
        /// </param>
        /// <param name="seconds">
        /// The seconds.
        /// </param>
        public CachingCallHandlerAttribute(int hours, int minutes, int seconds)
        {
            this.expirationTime = new TimeSpan(hours, minutes, seconds);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The create handler.
        /// </summary>
        /// <param name="ignored">
        /// The ignored.
        /// </param>
        /// <returns>
        /// </returns>
        public override ICallHandler CreateHandler(IUnityContainer ignored)
        {
            return this;
        }

        #endregion

        #region Implemented Interfaces

        #region ICallHandler

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
        /// </returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
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

        #endregion

        #endregion

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
                        sb.Append(input.GetHashCode().ToString());
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
    }
}