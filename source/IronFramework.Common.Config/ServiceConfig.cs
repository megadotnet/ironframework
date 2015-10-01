namespace IronFramework.Common.Config
{
    using System;


 
    public class ServiceConfig : BaseConfig
    {

        public ServiceConfig(System.Xml.XmlNode node)
            : base(node)
        {

        }


        static ServiceConfig()
        {
            ConfigSectionName = typeof(ServiceConfig).Name;
        }

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
