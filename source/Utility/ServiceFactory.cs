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
            var container = Singleton.GetInstance<IUnityContainer>(() => new UnityContainer());

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EntLib.config.xml");
            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var section = (UnityConfigurationSection)config.GetSection("unity");

            try
            {
                section.Configure(container, "DefContainer");
            }
            catch (InvalidOperationException ioe)
            {
                var logWriter = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();
                logWriter.Write(ioe,"ExceptionLogger");
                throw;
            }     

            serviceLocator = new UnityServiceLocator(container);
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