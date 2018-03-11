// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceConfig.cs" company="Megadotnet">
// Copyright (c) 2010-2018 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//  ServiceConfig
// </summary>
// --------------------------------------------------------------------------------------------------------------------	

namespace IronFramework.Common.Config
{
    using System;

    /// <summary>
    /// ServiceConfig
    /// </summary>
    /// <seealso cref="IronFramework.Common.Config.BaseConfig" />
   /// <example>
    /// <code>
    /// <![CDATA[
    ///   <configSections>
    ///      <section name = "ServiceConfig" type="IronFramework.Common.Config.SectionHandler`1[[IronFramework.Common.Config.ServiceConfig, IronFramework.Common.Config]],IronFramework.Common.Config" />
    ///      </configSections>
    ///<ServiceConfig>
    ///  <URI>http://localhost:14488/</URI>
    ///  <AccessControlURI>http://10.1.100.9:6000</AccessControlURI>
    ///</ServiceConfig>
    /// ]]>
    /// </code>
    /// </example>
    public class ServiceConfig : BaseConfig
    {
        #region Must Implement
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceConfig"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public ServiceConfig(System.Xml.XmlNode node)
            : base(node)
        {

        }


        /// <summary>
        /// Initializes the <see cref="ServiceConfig"/> class.
        /// </summary>
        static ServiceConfig()
        {
            ConfigSectionName = typeof(ServiceConfig).Name;
        }

        #endregion

        /// <summary>
        /// Gets the mq ip address.
        /// </summary>
        /// <value>
        /// The mq ip address.
        /// </value>
        public static string SectionName
        {
            get
            {
                return configSection["SectionName"];
            }
        }

        /// <summary>
        /// Gets the URI.
        /// </summary>
        /// <value>
        /// The URI.
        /// </value>
        public static string URI
        {
            get
            {
                return configSection["URI"];
            }
        }


        /// <summary>
        /// Gets the access control URI.
        /// </summary>
        /// <value>
        /// The access control URI.
        /// </value>
        public static string AccessControlURI
        {
            get
            {
                return configSection["AccessControlURI"];
            }
        }


    }
}
