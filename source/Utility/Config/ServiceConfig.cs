namespace IronFramework.Utility
{
    using System;

    public class ServiceConfig
    {
         private System.Xml.XmlNode m_section;
         private static readonly string ConfigSectionName = "ServiceConfig";

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageQueueConfig"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
         public ServiceConfig(System.Xml.XmlNode node)
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
         private static ServiceConfig configSection
        {
            get
            {
                ServiceConfig config = (ServiceConfig)System.Configuration.ConfigurationManager.GetSection(ConfigSectionName);
                if (config == null)
                {
                    throw new ApplicationException("Failed to get ServiceConfig configuration from App.config.");
                }
                return config;
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

        /// <summary>
        /// Gets the mq ip address.
        /// </summary>
        /// <value>
        /// The mq ip address.
        /// </value>
        public static string URI
        {
            get
            {
                return configSection["URI"];
            }
        }


        public static string AccessControlURI
        {
            get
            {
                return configSection["AccessControlURI"];
            }
        }


        public static string NotmaQXURI
        {
            get
            {
                return configSection["NotmaQXURI"];
            }
        }

        public static string MessageUrl {
            get {
                return configSection["MessageUrl"];
            }
        }
    }
}
