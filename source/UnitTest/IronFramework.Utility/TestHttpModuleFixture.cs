// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestHttpModuleFixture.cs" company="Megadotnet">
//    Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The test http module fixture.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UnitTest.TestUtility
{
    using System;
    using System.Collections.Specialized;
    using System.Net;
    using System.Web;
    using Moq;
    using IronFramework.Utility.Web.HttpModule;
    using Xunit;

    /// <summary>
    /// The test http module fixture.
    /// </summary>
    public class TestHttpModuleFixture
    {
        /// <summary>
        /// The _http cache policy.
        /// </summary>
        private readonly Mock<HttpCachePolicyBase> _httpCachePolicy;

        /// <summary>
        /// The _http context.
        /// </summary>
        private readonly Mock<HttpContextBase> _httpContext;

        /// <summary>
        /// The _http request.
        /// </summary>
        private readonly Mock<HttpRequestBase> _httpRequest;

        /// <summary>
        /// The _http response.
        /// </summary>
        private readonly Mock<HttpResponseBase> _httpResponse;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestHttpModuleFixture"/> class.
        /// </summary>
        public TestHttpModuleFixture()
        {
            _httpContext = new Mock<HttpContextBase>();
            _httpRequest = new Mock<HttpRequestBase>();
            _httpResponse = new Mock<HttpResponseBase>();
            _httpCachePolicy = new Mock<HttpCachePolicyBase>();

            _httpContext.SetupGet(context => context.Request).Returns(_httpRequest.Object);
            _httpContext.SetupGet(context => context.Response).Returns(_httpResponse.Object);
        }


        /// <summary>
        /// Called when [begin request_ should_ compress_ whitespace].
        /// </summary>
        [Fact]
        public void OnBeginRequest_Should_Compress_Whitespace()
        {
            //arrange
            _httpRequest.SetupGet(request => request.Url).Returns(new Uri("http://www.mysite.com/"));
            _httpRequest.SetupGet(request => request.RawUrl).Returns("http://www.mysite.com/default.aspx");

            _httpRequest.SetupGet(request => request.Headers)
                .Returns(new NameValueCollection {{"Accept-Encoding", "Gzip"}});

            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                _httpResponse.SetupGet(response => response.Filter).Returns(client.OpenWrite("http://www.hao123.net"));
            }

            _httpCachePolicy.SetupGet(hc => hc.VaryByHeaders).Returns(new HttpCacheVaryByHeaders());
            _httpResponse.SetupGet(response => response.Cache).Returns(_httpCachePolicy.Object);


            // act
            var module = new CompressWhitespaceModule();
            module.OnBeginRequest(_httpContext.Object);

            //assert
            _httpResponse.VerifyAll();
        }


        /// <summary>
        /// Called when [pre send request headers_ should_ remove server info_ header].
        /// </summary>
        [Fact]
        public void OnPreSendRequestHeaders_Should_RemoveServerInfo_Header()
        {
            //arrange
            _httpRequest.SetupGet(request => request.Url).Returns(new Uri("http://www.mysite.com/"));
            _httpResponse.SetupGet(response => response.Headers)
                .Returns(new NameValueCollection {{"Server", "Server, X-Powered-By"}});

            // act
            var module = new RemoveServerInfoModule();
            module.OnPreSendRequestHeaders(_httpContext.Object);

            _httpResponse.VerifyAll();
        }
    }
}