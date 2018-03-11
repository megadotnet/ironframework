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
    using System.Configuration;

    /// <summary>
    /// SectionHandler for outside config files
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[
    ///   <configSections>
    ///         <section name = "MyMQConfig" type="IronFramework.Common.Config.SectionHandler`1[[Megadotnet.MessageMQ.Adapter.Config.MyMQConfig, Megadotnet.MessageMQ.Adapter]],IronFramework.Common.Config"/>
    ///      </configSections>
    ///    <MyMQConfig>
    ///       <mqidaddress>tcp://127.0.0.1:61616/</mqidaddress>
    ///      <queuedestination>PushMessageQueue</queuedestination>
    ///    </MyMQConfig>
    /// ]]>
    /// </code>
    /// </example>
    public class SectionHandler<T> : IConfigurationSectionHandler
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
