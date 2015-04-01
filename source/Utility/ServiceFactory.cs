// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceFactory.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   ServiceFactory
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility
{
    using System;
    using System.Configuration;
    using System.IO;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging;
    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

    /// <summary>
    /// Service Factory
    /// </summary>
    public class ServiceFactory
    {
        #region Constants and Fields

        /// <summary>
        /// The service locator.
        /// </summary>
        public static readonly IServiceLocator serviceLocator;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="ServiceFactory"/> class. 
        /// </summary>
        static ServiceFactory()
        {
            var container = PrepareContainer();

            serviceLocator = new UnityServiceLocator(container);
        }

        public static IUnityContainer PrepareContainer()
        {
            var container = Singleton.GetInstance<IUnityContainer>(() => new UnityContainer());

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EntLib.config.xml");
            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            try
            {
                var section = (UnityConfigurationSection)config.GetSection("unity");
                section.Configure(container, "DefContainer");

                //For Entlib 6 :Exception Handling Application Block objects can no longer be created automatically from the Unity DI container. 
                IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
                LogWriterFactory logWriterFactory = new LogWriterFactory(configurationSource);
                Logger.SetLogWriter(logWriterFactory.Create());
                // Singleton
                ExceptionPolicyFactory exceptionPolicyFactory = new ExceptionPolicyFactory(configurationSource);
                ExceptionPolicy.SetExceptionManager(exceptionPolicyFactory.CreateManager());
            }
            catch (InvalidOperationException ioe)
            {
                Logger.Write(ioe, "ExceptionLogger");
                throw;
            }
            return container;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T">
        /// type
        /// </typeparam>
        /// <returns>
        /// target type
        /// </returns>
        public static T GetInstance<T>()
        {
            return serviceLocator.GetInstance<T>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns> target type</returns>
        public static T GetInstance<T>(string key)
        {
            return serviceLocator.GetInstance<T>(key);
        }

        #endregion
    }
}