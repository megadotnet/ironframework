// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestUnityDependencyResolver.cs" company="Megadotnet">
//   Copyright (c) 2010-2012 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   Unit test for unity dependency resolver.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UnitTest.TestUtility
{
    using System;
    using IronFramework.Utility.UI;
    using Xunit;
    using System.Web.Mvc;
    using Microsoft.Practices.Unity;
    using System.Web.Routing;

    /// <summary>
    /// TestUnityDependencyResolver
    /// </summary>
   // public class TestUnityDependencyResolver
   // {
        /// <summary>
        /// Tests the get service from dependency resolver.
        /// </summary>
        //[Fact]
        //public void TestGetServiceFromDependencyResolver()
        //{
        //    //arrange
        //    IUnityContainer container = InitialUnityContainer();
        //    IDependencyResolver dependencyResolver = new UnityDependencyResolver(container);

        //    //act
        //    var controllerActivator = dependencyResolver.GetService<IControllerActivator>();
       
        //    //assert
        //    Assert.NotNull(controllerActivator);
        //}

        //[Fact]
        //public void TestCreateContronllerFromCustomControllerActivatorWithUnity()
        //{
        //    //arrange
        //    IUnityContainer container = InitialUnityContainer();
        //    IDependencyResolver dependencyResolver = new UnityDependencyResolver(container);

        //    //act
        //    var controllerActivator = dependencyResolver.GetService<IControllerActivator>();
        //    var requestContext = new RequestContext();
        //    var controller = controllerActivator.Create(requestContext, typeof(TestingController));

        //    //assert
        //    Assert.NotNull(controllerActivator);
        //    Assert.NotNull(controller);
        //    Assert.IsType<TestingController>(controller);
        //}

        /// <summary>
        /// Gets the unity container.
        /// </summary>
        /// <returns></returns>
        //private IUnityContainer InitialUnityContainer()
        //{
        //    var container = new UnityContainer()
        //        .RegisterType<IControllerActivator, CustomControllerActivator>()
        //        .RegisterType<IController, TestingController>();

        //    return container;
        //}
    //}

    /// <summary>
    /// Unit test object
    /// </summary>
    public class TestingController : Controller
    {

    }
}
