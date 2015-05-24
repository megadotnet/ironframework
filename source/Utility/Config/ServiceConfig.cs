namespace IronFramework.Utility
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


    }
}
