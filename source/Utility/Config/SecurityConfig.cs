namespace IronFramework.Utility
{
    using System;

    public class SecurityConfig:BaseConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityConfig"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public SecurityConfig(System.Xml.XmlNode node):base(node)
        {
          
        }

        static SecurityConfig()
        {
            ConfigSectionName = typeof(SecurityConfig).Name;
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


    }  
}
