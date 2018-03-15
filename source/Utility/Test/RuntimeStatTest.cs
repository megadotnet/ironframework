// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuntimeStatTest.cs" company="Megadotnet">
// Copyright (c) 2010-2018 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//  RuntimeStatTest
// </summary>
// --------------------------------------------------------------------------------------------------------------------	

namespace IronFramework.Utility.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class RuntimeStatTest
    {
        #region Public Methods

        /// <summary>
        /// Foreaches the specified input.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        public static void Foreach<T>(this IEnumerable<T> input, Action<T> action)
        {
            foreach (T item in input)
            {
                action(item);
            }
        }

        /// <summary>
        /// Performances the watch.
        /// </summary>
        /// <param name="targetaction">
        /// The targetaction.
        /// </param>
        /// <returns>
        /// The performance watch.
        /// </returns>
        public static long PerformanceWatch(Action targetaction)
        {
            var sw = new Stopwatch();
            sw.Reset();
            sw.Start();

            targetaction();

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        #endregion
    }
}
