// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectionHandler.cs" company="Megadotnet">
// Copyright (c) 2010-2018 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//  SectionHandler
// </summary>
// --------------------------------------------------------------------------------------------------------------------	
namespace IronFramework.Common.Config
{
    using System;

    /// <summary>
    /// SectionHandler
    /// </summary>
    public class SectionHandler<T> : System.Configuration.IConfigurationSectionHandler
        where T : BaseConfig
    {
        /// <summary>
        /// Creates a configuration section handler.
        /// </summary>
        /// <param name="parent">Parent object.</param>
        /// <param name="configContext">Configuration context object.</param>
        /// <param name="section">Section XML node.</param>
        /// <returns>
        /// The created section handler object.
        /// </returns>
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
           var t=(T)Activator.CreateInstance(typeof(T), section);
           
            return t;
        }
    }
}
