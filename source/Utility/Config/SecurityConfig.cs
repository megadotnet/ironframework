namespace IronFramework.Utility
{
    using System;

    public class SecurityConfig
    {
          /// <summary>
        /// The m_section
        /// </summary>
        private System.Xml.XmlNode m_section;
        /// <summary>
        /// The configuration section name
        /// </summary>
        private static readonly string ConfigSectionName = "SecurityConfig";


        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityConfig"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public SecurityConfig(System.Xml.XmlNode node)
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
                    throw new ApplicationException("Failed to get configuration from App.config.");
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
        /// Gets the only allow ip.
        /// </summary>
        /// <value>
        /// The only allow ip.
        /// </value>
        public static string OnlyAllowIP
        {
            get
            {
                var myvalue = configSection["OnlyAllowIP"];
                return myvalue;
            }
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public static string UserID
        {
            get
            {
                var myvalue = configSection["UserID"];
                return myvalue;
            }
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public static string Password
        {
            get
            {
                var myvalue = configSection["Password"];
                return myvalue;
            }
        }

        public static string MessageSendAPPCODE
        {
            get {
                var value = configSection["MessageSendAPPCODE"];
                return value;
            }
        }

        public static string MessageSendAPPPASSWORD
        {
            get
            {
                var value = configSection["MessageSendAPPPASSWORD"];
                return value;
            }
        }

    }  
}
