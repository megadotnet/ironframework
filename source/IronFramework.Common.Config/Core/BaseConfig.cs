// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseConfig.cs" company="Megadotnet">
// Copyright (c) 2010-2018 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//  BaseConfig
// </summary>
// --------------------------------------------------------------------------------------------------------------------	
namespace IronFramework.Common.Config
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// BaseConfig
    /// </summary>
    public class BaseConfig
    {
        /// <summary>
        /// The m_section
        /// </summary>
        protected System.Xml.XmlNode m_section;

        /// <summary>
        /// Gets or sets the name of the configuration section.
        /// </summary>
        /// <value>
        /// The name of the configuration section.
        /// </value>
        public static string ConfigSectionName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseConfig"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public BaseConfig(System.Xml.XmlNode node)
        {
            this.m_section = node;
        }

        /// <summary>
        /// Gets the configuration section.
        /// </summary>
        /// <value>
        /// The configuration section.
        /// </value>
        /// <exception cref="System.ApplicationException">Failed to get configuration from App.config.</exception>
        protected static BaseConfig configSection
        {
            get
            {
                object configSection = System.Configuration.ConfigurationManager.GetSection(ConfigSectionName);
                if (configSection == null)
                {
                    throw new ArgumentException(string.Format("Cannot get {0} configuration from config files.", ConfigSectionName));
                }

                BaseConfig specificConfig = (BaseConfig)configSection;
                if (specificConfig == null)
                {
                    throw new ApplicationException(string.Format("Failed to get {0} configuration from App.config.", ConfigSectionName));
                }
                return specificConfig;
            }
        }

        /// <summary>
        /// Gets the <see cref="System.String"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="System.String"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string this[string key]
        {
            get
            {
                System.Xml.XmlNode node = this.m_section.SelectSingleNode(key);
                if (node != null)
                    return node.InnerText;
                else
                    return null;
            }
        }
    }

}
