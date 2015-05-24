using System;
namespace IronFramework.Utility
{
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
