// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Singleton.cs" company="Megadotnet">
//   Copyright (c) 2010-2018 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   Singleton
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility
{
    using System;
    using System.Threading;

    /// <summary>
    /// Singleton
    /// </summary>
    public static class Singleton
    {
        #region Public Methods

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T">
        /// Func
        /// </typeparam>
        /// <param name="op">
        /// The op.
        /// </param>
        /// <returns>
        /// T
        /// </returns>
        public static T GetInstance<T>(Func<T> op) where T : class
        {
            if (Storage<T>.s_instance == null)
            {
                lock (typeof(Storage<T>))
                {
                    if (Storage<T>.s_instance == null)
                    {
                        T temp = op();
                        Thread.MemoryBarrier();
                        Storage<T>.s_instance = temp;
                    }
                }
            }

            return Storage<T>.s_instance;
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T">
        /// T
        /// </typeparam>
        /// <returns>
        /// T
        /// </returns>
        public static T GetInstance<T>() where T : class, new()
        {
            return GetInstance(() => new T());
        }

        #endregion

        /// <summary>
        /// Storage
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        private static class Storage<T>
        {
            #region Constants and Fields

            /// <summary>
            /// The s_instance.
            /// </summary>
            internal static T s_instance;

            #endregion
        }
    }

    /// <summary>
    /// Singleton under .net framework 4.0
    /// </summary>
    /// <typeparam name="T">specific class</typeparam>
    /// <seealso cref="http://msdn.microsoft.com/en-us/library/dd642331.aspx"/>
    /// <remarks>author Petter Liu http://wintersun.cnblogs.com </remarks>
    public static class Singleton<T> where T : class
    {
        // Initializes a new instance of the Lazy<T> class. When lazy initialization occurs, the specified
        //     initialization function and initialization mode are used.
        private static readonly Lazy<T> current = new Lazy<T>(
            () =>
                Activator.CreateInstance<T>(),    // factory method
                true);                                       // double locks

        public static object Current
        {
            get { return current.Value; }
        }
    }
}