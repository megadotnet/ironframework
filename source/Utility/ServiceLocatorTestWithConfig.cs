// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceLocatorTestWithConfig.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   ServiceLocatorConfig
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility
{
    using System.Configuration;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel.Unity;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using Microsoft.Practices.Unity.InterceptionExtension;

    /// <summary>
    /// ServiceLocatorConfig
    /// </summary>
    public class ServiceLocatorConfig
    {
        #region Constants and Fields

        /// <summary>
        /// IServiceLocator
        /// </summary>
        protected readonly IServiceLocator locator;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocatorConfig"/> class.
        /// </summary>
        public ServiceLocatorConfig()
        {
            this.locator = this.CreateServiceLocator();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the service locator.
        /// </summary>
        /// <returns>
        /// </returns>
        protected IServiceLocator CreateServiceLocator()
        {
            IUnityContainer container = new UnityContainer().AddNewExtension<Interception>();
            var map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = "EntLib.Config";

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var section = (UnityConfigurationSection)config.GetSection("unity");

            section.Containers["DefContainer"].Configure(container);
            return new UnityServiceLocator(container);
        }

        /// <summary>
        /// The config with enterprise library container.
        /// </summary>
        private static void ConfigWithEnterpriseLibraryContainer()
        {
            // Create the container
            IUnityContainer container = new UnityContainer();

            // Configurator will read Enterprise Library configuration 
            // and set up the container
            var configurator = new UnityContainerConfigurator(container);

            // Configuration source holds the new configuration we want to use 
            // load this in your own code
            IConfigurationSource configSource = ReadConfigSource();

            // Configure the container
            EnterpriseLibraryContainer.CreateDefaultContainer(configSource);

            // Wrap in ServiceLocator
            IServiceLocator locator = new UnityServiceLocator(container);

            // And set Enterprise Library to use it
            EnterpriseLibraryContainer.Current = locator;
        }

        /// <summary>
        /// The read config source.
        /// </summary>
        /// <returns>
        /// </returns>
        private static IConfigurationSource ReadConfigSource()
        {
            return new FileConfigurationSource("EntLib.config.xml");
        }

        #endregion
    }
}