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
    public interface ITypeAdapter<S, T>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <typeparam name="S">Source type</typeparam>
        /// <typeparam name="T">Target type</typeparam>
        /// <param name="source">The source instance</param>
        /// <returns>Target type</returns>
        T Transform<S, T>(S source);
    }

    /// <summary>
    /// TypeAdapter
    /// </summary>
    /// <typeparam name="S">Source</typeparam>
    /// <typeparam name="T">Target</typeparam>
    public class TypeAdapter<S, T> : ITypeAdapter<S, T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeAdapter&lt;S, T&gt;"/> class.
        /// </summary>
        public TypeAdapter()
       {
            //We do not need complete mapping between entity and DTO
           //Mapper.AssertConfigurationIsValid();
       }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <typeparam name="S">Source type</typeparam>
        /// <typeparam name="T">Target type</typeparam>
        /// <param name="source">The source instance</param>
        /// <returns>Target type</returns>
        public virtual T Transform<S, T>(S source)
        {
            CreateMap<S, T>();
            return GetTarget<S, T>(source);
        }

        /// <summary>
        /// Gets the target.
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        protected virtual T GetTarget<S, T>(S source)
        {
            return Mapper.Map<S, T>(source);
        }

        /// <summary>
        /// Gets the target.
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="dest">The dest.</param>
        /// <returns></returns>
        protected virtual T GetTarget<S, T>(S source, T dest)
        {
            return Mapper.Map<S, T>(source,dest);
        }

        /// <summary>
        /// Creates the map.
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="T"></typeparam>
        protected virtual void CreateMap<S, T>()
        {
            Mapper.CreateMap<S, T>();
        }

    }




}
