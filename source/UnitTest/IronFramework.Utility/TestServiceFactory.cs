// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestServiceFactory.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The test service factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTest
{
    using System;
    using System.Configuration;
    using System.IO;

    using BusinessObject;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    using IronFramework.Utility;
    using Xunit;

    /// <summary>
    /// The test service factory.
    /// </summary>
    public class TestServiceFactory
    {
        #region Public Methods

        /// <summary>
        /// The test direct get customerobject.
        /// </summary>
        [Fact]
        public void TestDirectGetCustomerobject()
        {
            var container = new UnityContainer();

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EntLib.config.xml");
            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var section = (UnityConfigurationSection)config.GetSection("unity");
            section.Configure(container, "DefContainer");

            var serviceocator = new UnityServiceLocator(container);

            var employee = serviceocator.GetInstance<IEmployeeBusinessObject>();

            Assert.NotNull(employee);
        }

        /// <summary>
        /// The test get customerobject.
        /// </summary>
        [Fact]
        public void TestGetCustomerobject()
        {
            // Get Customer object from service locator
            var employee = ServiceFactory.GetInstance<IEmployeeBusinessObject>();
            Assert.NotNull(employee);
        }



        #endregion
    }
}