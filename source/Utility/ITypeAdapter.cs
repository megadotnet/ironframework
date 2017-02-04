// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITypeAdapter.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   ITypeAdapter
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace IronFramework.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AutoMapper;

    /// <summary>
    /// Interface of TypeAdapter 
    /// </summary>
    /// <typeparam name="S">Source</typeparam>
    /// <typeparam name="T">Target</typeparam>
    /// <remarks>interface</remarks>
    public interface ITypeAdapter
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <typeparam name="S">Source type</typeparam>
        /// <typeparam name="T">Target type</typeparam>
        /// <param name="source">The source instance</param>
        /// <returns>Target type</returns>
        T Transform<S, T>(S source);


        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="instance">The instance.</param>
        /// <returns>T.</returns>
        T Transform<S, T>(S source, T instance);
    }

   



}
