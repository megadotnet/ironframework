namespace MvcApp.Tests.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Moq;
    using System.IO;
    using MVC5Web.Controllers;

    /// <summary>
    /// TestUtility
    /// </summary>
    public static class TestUtility
    {
        public static HttpContextBase FakeFileUploadHttpContextBase(string filename)
        {
            var fakedRequest = new Mock<HttpRequestBase>();
            var fakedFile = new Mock<HttpPostedFileBase>();
            fakedFile.SetupGet(t => t.FileName).Returns(filename);
            using (var inputStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                fakedFile.SetupGet(t => t.ContentLength).Returns((int)inputStream.Length);
                fakedFile.SetupGet(x => x.InputStream).Returns(inputStream);
            }
            
            var fakedFileCollection = new Mock<HttpFileCollectionBase>();
            fakedFileCollection.SetupGet(t => t.Count).Returns(1);
            fakedFileCollection.SetupGet(t => t[0]).Returns(fakedFile.Object);
            fakedRequest.SetupGet(t => t.Files).Returns(fakedFileCollection.Object);

            var fakedContext = new Mock<HttpContextBase>();

            fakedContext.Setup(t => t.Request).Returns(fakedRequest.Object);

            return fakedContext.Object;
        }

        /// <summary>
        /// Fakes the authenticated HTTP context.
        /// </summary>
        /// <returns>HttpContextBase</returns>
        public static HttpContextBase FakeAuthenticatedHttpContextBase()
        {
            return FakeAuthenticatedHttpContextBase("peterliu");
        }

        public static HttpContextBase FakeAuthenticatedHttpContextBase(string username)
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();
            var user = new Mock<IPrincipal>();
            var identity = new Mock<IIdentity>();


            request.Setup(c => c["rows"]).Returns("10");
            request.Setup(c => c["page"]).Returns("1");

            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);
            context.Setup(ctx => ctx.User).Returns(user.Object);

            user.Setup(ctx => ctx.Identity).Returns(identity.Object);

            identity.Setup(id => id.IsAuthenticated).Returns(true);
            identity.Setup(id => id.Name).Returns(username);

            return context.Object;
        }

        /// <summary>
        /// Sets the fake authenticated controller context.
        /// </summary>
        /// <param name="controller">The controller.</param>
        public static void SetFakeAuthenticatedControllerContext(this Controller controller)
        {
            var httpContext = FakeAuthenticatedHttpContextBase();
            ControllerContext context =
            new ControllerContext(
            new RequestContext(httpContext,
            new RouteData()), controller);
            controller.ControllerContext = context;
        }

        public static void SetFakeAuthenticatedControllerContext(this Controller controller, string username)
        {
            var httpContext = FakeAuthenticatedHttpContextBase(username);
            ControllerContext context =
            new ControllerContext(
            new RequestContext(httpContext,
            new RouteData()), controller);
            controller.ControllerContext = context;
        }


        public static void SetFakeFileUploadControllerContext(this Controller controller, string filename)
        {
            var httpContext = FakeFileUploadHttpContextBase(filename);
            ControllerContext context = new ControllerContext(new RequestContext(httpContext, new RouteData()), controller);
            controller.ControllerContext = context;
        }

        /// <summary>
        /// Gets the value from json result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonResult">The json result.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>T</returns>
        /// <exception cref="System.ArgumentException">propertyName not found;propertyName</exception>
        public static T GetValueFromJsonResult<T>(JsonResult jsonResult, string propertyName)
        {
            var property =
                jsonResult.Data.GetType().GetProperties()
                .Where(p => string.Compare(p.Name, propertyName) == 0)
                .FirstOrDefault();

            if (null == property)
                throw new ArgumentException("propertyName not found", "propertyName");
            return (T)property.GetValue(jsonResult.Data, null);
        }
    }
}
