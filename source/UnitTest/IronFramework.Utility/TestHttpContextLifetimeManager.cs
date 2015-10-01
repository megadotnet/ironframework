// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestHttpContextLifetimeManager.cs" company="Megadotnet">
//   Test HttpContextLifetimeManager
// </copyright>
// <summary>
//   Defines the TestHttpContextLifetimeManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UnitTest.TestUtility
{
    using IronFramework.Common.IOC.EntLib.IoC;
    using System;
    using System.IO;
    using System.Web;
    using Xunit;

    /// <summary>
    /// Unit Test for http context lifetime manager of Unity
    /// </summary>
    public class TestHttpContextLifetimeManager
    {
        /// <summary>
        /// Tests the set value and set value from HTTP context.
        /// </summary>
        [Fact]
        public void TestSetValueAndSetValueFromHttpContext()
        {
            // arrange
            this.InitialTestHttpContext();
            using (var httpContextLifetimeManger = new HttpContextLifetimeManager<TestingController>())
            {
                var testingController = new TestingController();

                // act
                httpContextLifetimeManger.SetValue(testingController);
                object controllerFromHttpContext = httpContextLifetimeManger.GetValue();

                // assert
                Assert.NotNull(controllerFromHttpContext);
                Assert.IsType<TestingController>(controllerFromHttpContext);
                Assert.Same(testingController, controllerFromHttpContext);
            }
        }
    
        /// <summary>
        /// Tests the delete value from HTTP context.
        /// </summary>
        [Fact]
        public void TestDeleteValueFromHttpContext()
        {
            // arrange
            this.InitialTestHttpContext();
            using (var httpContextLifetimeManger = new HttpContextLifetimeManager<TestingController>())
            {
                var testingController = new TestingController();

                // act
                httpContextLifetimeManger.SetValue(testingController);
                httpContextLifetimeManger.RemoveValue();
                object controllerFromHttpContext = httpContextLifetimeManger.GetValue();

                // assert
                Assert.Null(controllerFromHttpContext);
            }
        }

        /// <summary>
        /// Initials the test HTTP context.
        /// </summary>
        private void InitialTestHttpContext()
        {
            // create HttpContext
            var rd = new Random(10);
            int count = rd.Next(10);
            var request = new HttpRequest("anyrequest", "http://undefinedwebsite", null);
            using (var streamwriter = new StreamWriter("undefined" + count))
            {
                var response = new HttpResponse(streamwriter);
                streamwriter.Close();
                var context = new HttpContext(request, response);
                HttpContext.Current = context;
            }
            ;
        }
    }
}