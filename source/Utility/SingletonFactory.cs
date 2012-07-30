// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SingletonFactory.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   SingletonFactory
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility
{
    /// <summary>
    /// SingletonFactory
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    /// <typeparam name="TU">
    /// The type of the U.
    /// </typeparam>
    public class SingletonFactory<T, TU>
        where TU : class, T, new()
    {
        #region Properties

        /// <summary>
        /// Gets GetInstance.
        /// </summary>
        public static T GetInstance
        {
            get
            {
                return Singleton.GetInstance(() => new TU());
            }
        }

        #endregion
    }
}