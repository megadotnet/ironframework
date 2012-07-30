// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCutCrossingConcerns.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Megadotnet.  All rights reserved. 
// </copyright>
// <summary>
//   This test case for aop
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using IronFramework.Utility;
    using BusinessEntiies;
    using BusinessObject;
    using System.IO;
    using Microsoft.Practices.EnterpriseLibrary.Validation.PolicyInjection;
    using Microsoft.Practices.Unity.InterceptionExtension;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
    using Xunit;

    /// <summary>
    /// TestCutCrossingConcerns 
    /// </summary>
    /// <remarks>Current for Enterprise library</remarks>
    public class TestCutCrossingConcerns
    {
        /// <summary>
        /// The test aop with piab.
        /// </summary>
       [Fact]
        public void TestAOPWithPIAB()
        {
            var container = new UnityContainer();
            container.RegisterType<IEmployeeBusinessObject, EmployeeBusinessObject>(new InjectionConstructor());

            container.AddNewExtension<EnterpriseLibraryCoreExtension>();
            var ebo = container.Resolve<IEmployeeBusinessObject>();

            Assert.NotNull(ebo);     
        }


        /// <summary>
        /// The test aop with unity config files.
        /// </summary>
       [Fact]
        public void TestAOPWithUnityConfigFiles()
        {
            var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();
            var entity=ebo.GetEmployee(1);

            Assert.NotNull(entity);
        }

        /// <summary>
        /// The test direct Cut Crossing Concerns with PIAB.
        /// </summary>
       [Fact]
        public void TestDirectAOPWithPIAB()
        {
            var container = new UnityContainer();
            container.RegisterType<IEmployeeBusinessObject, EmployeeBusinessObject>(new InjectionConstructor());

            container.AddNewExtension<Interception>();
            container.AddNewExtension<EnterpriseLibraryCoreExtension>();
            container.Configure<Interception>().SetInterceptorFor<IEmployeeBusinessObject>(
                new TransparentProxyInterceptor());

            // Get Policy Injection Settings from the Configuration
            IConfigurationSource configSource = ConfigurationSourceFactory.Create();
            var policyInjectionsettings =
                (PolicyInjectionSettings)configSource.GetSection(PolicyInjectionSettings.SectionName);
            if (policyInjectionsettings != null)
            {
                policyInjectionsettings.ConfigureContainer(container, configSource);
            }

            var ebo = container.Resolve<IEmployeeBusinessObject>();
            Assert.NotNull(ebo);
         
        }

        /// <summary>
        /// The test_ ao p_ caching for get all employees.
        /// </summary>
       [Fact]
        public void Test_AOP_CachingForGetAllEmployees()
        {
            var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();
            Employee myemployee = ebo.GetEmployee(1);

            Assert.NotNull(myemployee);

            // Thread.Sleep(1000);
            Employee myemployee2 = ebo.GetEmployee(1);
            Assert.NotNull(myemployee2);
            Assert.Equal(myemployee, myemployee2);
        }

        /// <summary>
        /// The test_ ao p_ logging_function_ get employee.
        /// </summary>
       [Fact]
        public void Test_AOP_Logging_function_GetEmployee()
        {
            string loggingfilefullpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Generaltrace.log");
            var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();
            ebo.GetEmployee(1);

            Assert.True(File.Exists(loggingfilefullpath));
        }

        /// <summary>
        /// The test_ ao p_ validation_function_ get employee.
        /// </summary>
       [Fact]
        public void Test_AOP_Validation_function_GetEmployee()
        {
            Assert.Throws<ArgumentValidationException>(() =>
                {
                    var ebo = ServiceFactory.GetInstance<IEmployeeBusinessObject>();
                    ebo.GetEmployee(-1);
                });
        }
    }
}
