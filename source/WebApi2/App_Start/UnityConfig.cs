using IronFramework.Utility;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;
using System.IO;
using System.Web.Http;
using Unity.WebApi;

namespace WebApi2
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            IUnityContainer container = Singleton.GetInstance<IUnityContainer>(() => new UnityContainer());

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EntLib.config.xml");
            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            //try
            //{
                var section = (UnityConfigurationSection)config.GetSection("unity");
                section.Configure(container, "DefContainer");

            //}
            //catch (InvalidOperationException)
            //{
            //    throw;
            //}

            // register all your components with the container here
            // it is NOT necessary to register your controllers  
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}