// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectFactory.cs" company="Megadotnet">
//   Copyright (c) 2010-2015 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   ObjectFactory
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessObject
{
    using System.Data.Entity;
	using System.IO;
    using System.Configuration;
    using System;
    using Microsoft.Practices.Unity.Configuration;
    using BusinessEntities;

    using DataAccessObject.Repositories;
    using Microsoft.Practices.Unity;
    
    /// <summary>
    /// ObjectFactory
    /// </summary>
    public class ObjectFactory
    {
       private static IUnityContainer container;

	    /// <summary>
        /// ObjectFactory
        /// </summary>
        /// <example><code>
        /// <![CDATA[
        ///   <appSettings>
        ///<add key="UsingXmlConfigForUnity" value="true" />
        ///</appSettings>
        /// ]]>
        /// </code></example>
       static ObjectFactory()
       {
           string appSetting = ConfigurationManager.AppSettings["UsingXmlConfigForUnity"];
           if (!string.IsNullOrEmpty(appSetting) && Convert.ToBoolean(appSetting))
           {
               InitFromXmlFile();
           }
           else
           {
            container = new UnityContainer();
			container.RegisterType<IUnitOfWork, EFUnitOfWork>();
		    container.RegisterType< DataAccessObject.Repositories.IStoredProcedureFunctionsDAO, DataAccessObject.Repositories.StoredProcedureFunctionsDAO>();
			container.RegisterType<DbContext, AdventureWorksEntities>(new InjectionConstructor());
            container.RegisterType<IObjectContext, ObjectContextAdapter>();
		    //for unit testing
            //container.RegisterType<IObjectContext, FakeContextAdapter>();
		            container.RegisterType<IRepository<Address>,EFRepository<Address>>();	
            container.RegisterType<IRepository<Contact>,EFRepository<Contact>>();	
            container.RegisterType<IRepository<Employee>,EFRepository<Employee>>();	
            container.RegisterType<IRepository<EmployeePayHistory>,EFRepository<EmployeePayHistory>>();	
           }
        }

        private static void InitFromXmlFile()
        {
            container =  new UnityContainer();

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DALConfig.xml");
            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            var section = (UnityConfigurationSection)config.GetSection("unity");
            section.Configure(container, "DefContainer");
        }
         
       /// <summary>
       /// Gets the instance.
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <returns></returns>
        public static T GetInstance<T>()
        {
            return container.Resolve<T>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="u">The u.</param>
        /// <returns></returns>
        public static T GetInstance<T, U>(U u)
        {
           return container.Resolve<T>(new DependencyOverride<U>(u));
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="Y"></typeparam>
        /// <param name="u">The u.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public static T GetInstance<T, U, Y>(U u, Y y)
        {
            return container.Resolve<T>(new DependencyOverride<U>(u), new DependencyOverride<Y>(y));
        }

    }
	
}