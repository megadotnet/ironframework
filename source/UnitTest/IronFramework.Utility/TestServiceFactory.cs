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
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel.Unity;
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
        /// The test ent lib validation.
        /// </summary>
        [Fact]
        public void TestEntLibValidation()
        {
            var valFactory = ServiceFactory.GetInstance<ValidatorFactory>();

            var myCustomer = new Customer();
            myCustomer.CustomerId = -2;
            myCustomer.CustomerName = "This is testname for current product";
            Validator<Customer> customerValidator = valFactory.CreateValidator<Customer>();
            ValidationResults results = customerValidator.Validate(myCustomer);

            Console.WriteLine(results.ToString());

            // Check if the ValidationResults detected any validation errors.
            if (results.IsValid)
            {
                Console.WriteLine("There were no validation errors.");
            }
            else
            {
                Console.WriteLine("The following {0} validation errors were detected:", results.Count);

                // Iterate through the collection of validation results.
                foreach (ValidationResult item in results)
                {
                    // Show the target member name and current value.
                    Console.WriteLine(
                        "Target:'{0}' Key:'{1}' Tag:'{2}' Message:'{3}'", item.Target, item.Key, item.Tag, item.Message);
                }
            }

            Assert.False(results.IsValid);
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

        /// <summary>
        /// The test get exception manager from customer service locator.
        /// </summary>
        [Fact]
        public void TestGetExceptionManagerFromCustomerServiceLocator()
        {
            var container = new UnityContainer();

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EntLib.config.xml");
            var map = new ExeConfigurationFileMap { ExeConfigFilename = path };

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var section = (UnityConfigurationSection)config.GetSection("unity");
            section.Configure(container, "DefContainer");

            var serviceocator = new UnityServiceLocator(container);

            var exceptionManager = serviceocator.GetInstance<ExceptionManager>();

            Assert.NotNull(exceptionManager);
        }

        /// <summary>
        /// The test get exception manager from default ent lib container.
        /// </summary>
        [Fact]
        public void TestGetExceptionManagerFromDefaultEntLibContainer()
        {
            var exceptionManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();

            Assert.NotNull(exceptionManager);
        }

        /// <summary>
        /// The test get exception manager from service locator.
        /// </summary>
        [Fact]
        public void TestGetExceptionManagerFromServiceLocator()
        {
            // Create the container
            var container = new UnityContainer();

            // Configurator will read Enterprise Library configuration 
            // and set up the container
            var configurator = new UnityContainerConfigurator(container);

            // Configuration source holds the new configuration we want to use 
            // load this in your own code
            var configSource = new FileConfigurationSource("EntLib.config.xml");

            // Configure the container
            EnterpriseLibraryContainer.CreateDefaultContainer(configSource);

            // Wrap in ServiceLocator
            var locator = new UnityServiceLocator(container);

            // And set Enterprise Library to use it
            EnterpriseLibraryContainer.Current = locator;

            var exceptionManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();

            Assert.NotNull(exceptionManager);
        }

        #endregion
    }
}