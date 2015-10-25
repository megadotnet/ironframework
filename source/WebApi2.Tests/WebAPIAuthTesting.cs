using DataServiceClient;
using IronFramework.Common.Config;
using IronFramework.Utility;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;
using WebApi2.Controllers;
using Xunit;
using FluentAssertions;
using Microsoft.Owin.Testing;


namespace WebApi2.Tests
{
    public class WebAPIAuthTesting
    {
        private IRESTAPIWrapperClinet restclient = new RESTAPIWrapperClinet("http://localhost:3956/");

        /// <summary>
        /// Tests the client.
        /// </summary>
        /// <returns></returns>
        /// <see cref="http://stackoverflow.com/questions/11775594/how-to-secure-an-asp-net-web-api#"/>
        /// <seealso cref="http://stackoverflow.com/questions/27361358/dealing-with-long-bearer-tokens-from-webapi-by-providing-a-surrogate-token"/>
        /// <seealso cref="http://www.jayway.com/2012/03/13/httpclient-makes-get-and-post-very-simple/"/>
        [Fact]
        public async Task TestWithHttpClient()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3956/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string date = DateTime.UtcNow.ToString("u");
                // HTTP GET
                string uri = "/api/Values";
                string methodType = "GET";
                string querystring = "id=11";

                string message = string.Join("\n", methodType, date, uri.ToLower(), querystring);


                string token = VerifyTransactionSN.ComputeHash(SecurityConfig.Password, message);
                Console.WriteLine(token);
                // token = "ppj7m0bW4feYueB770wEb8t+wds/09Gy7ZONlbLTxes=";
                client.DefaultRequestHeaders.Add("Authentication", string.Format("{0}:{1}", SecurityConfig.Password, token));
                client.DefaultRequestHeaders.Add("Timestamp", date);


                string routingUrl = uri + "?" + querystring;
                var response = await client.GetAsync(routingUrl);
                Assert.True(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.StatusCode);
                    string result = await response.Content.ReadAsStringAsync();
                    string expectedResult = "\"value\"";
                    Assert.Equal(expectedResult, result);
                }


            };

        }

        [Fact]
        public async Task TestHttpClientPost()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3956/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string date = DateTime.UtcNow.ToString("u");
                client.DefaultRequestHeaders.Add("Timestamp", date);

                //string token=CreateToken()
                // HTTP GET
                string uri = "/api/Values/PostCity";
                string methodType = "POST";
                string querystring = "";

                string message = string.Join("\n", methodType, date, uri.ToLower(), querystring);
                string token = VerifyTransactionSN.ComputeHash(SecurityConfig.Password, message);
                Console.WriteLine(token);

                client.DefaultRequestHeaders.Add("Authentication", string.Format("{0}:{1}", SecurityConfig.Password, token));

                string routingUrl = uri + "?" + querystring;

                var postmodel = new CityModel { CityShortName = "文山", IcaoCode = "ZPPP" };

                var response = await client.PostAsJsonAsync(uri, postmodel);
                Assert.True(response.IsSuccessStatusCode);
            };

        }

        [Fact]
        public async Task TestClientPostWithJsonFormatInRequestBody()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3956/");

                CreateAuthDelegateHeader(client);


                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string date = DateTime.UtcNow.ToString("u");
                client.DefaultRequestHeaders.Add("Timestamp", date);

                //string token=CreateToken()
                // HTTP GET
                string uri = "/api/Values/PostCity";
                string methodType = "POST";
                var postmodel = new CityModel { CityShortName = "文山", IcaoCode = "ZPPP" };

                string querystring = restclient.GetQueryString(postmodel, null);

                string message = string.Join("\n", methodType, date, uri.ToLower(), querystring);
                string token = VerifyTransactionSN.ComputeHash(SecurityConfig.Password, message);
                Console.WriteLine("message:{0} token:{1}", message,token);

                client.DefaultRequestHeaders.Add("Authentication", string.Format("{0}:{1}", SecurityConfig.Password, token));

                string routingUrl = uri + "?" + querystring;



                var response = await client.PostAsJsonAsync(uri, postmodel);
                Assert.True(response.IsSuccessStatusCode);
            };

        }

        [Fact]
        public async Task TestClientPutWithJsonFormatInRequestBody()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3956/");

                CreateAuthDelegateHeader(client);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string date = DateTime.UtcNow.ToString("u");
                client.DefaultRequestHeaders.Add("Timestamp", date);

                //string token=CreateToken()
                // HTTP PUT
                string uri = "/api/Values/UpdateWithPut";
                string methodType = HttpMethod.Put.ToString().ToUpper();
                var postmodel = new CityModel { CityShortName = "文山", IcaoCode = "ZPPP" };

                string querystring = restclient.GetQueryString(postmodel, null);

                string message = string.Join("\n", methodType, date, uri.ToLower(), querystring);
                string token = VerifyTransactionSN.ComputeHash(SecurityConfig.Password, message);
                Console.WriteLine("message:{0} token:{1}", message, token);

                client.DefaultRequestHeaders.Add("Authentication", string.Format("{0}:{1}", SecurityConfig.Password, token));

                string routingUrl = uri + "?" + querystring;

                var response = await client.PutAsJsonAsync(uri, postmodel);
                Assert.True(response.IsSuccessStatusCode);
            };
        }

        /// <summary>
        /// Tests the client delete.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestClientDelete()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3956/");

                CreateAuthDelegateHeader(client);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string date = DateTime.UtcNow.ToString("u");
                client.DefaultRequestHeaders.Add("Timestamp", date);

                //string token=CreateToken()
                // HTTP DELETE
                string uri = "/api/Values/2";
                string methodType = HttpMethod.Delete.ToString().ToUpper();


                string querystring = "";

                string message = string.Join("\n", methodType, date, uri.ToLower(), querystring);
                string token = VerifyTransactionSN.ComputeHash(SecurityConfig.Password, message);
                Console.WriteLine("message:{0} token:{1}", message, token);

                client.DefaultRequestHeaders.Add("Authentication", string.Format("{0}:{1}", SecurityConfig.Password, token));

                var response = await client.DeleteAsync(uri);
                Assert.True(response.IsSuccessStatusCode);
            };
        }

        /// <summary>
        /// Creates the authentication delegate header.
        /// </summary>
        /// <param name="client">The client.</param>
        private static void CreateAuthDelegateHeader(HttpClient client)
        {
            string username;
            string password;
            GetConfigSetionValues(out username, out password);
            client.DefaultRequestHeaders.Accept.Clear();
           
            //auth
            client.DefaultRequestHeaders.Add("X-MonsterAppApiKey", string.Format("{0}:{1}", username, password));
        }

        /// <summary>
        /// Gets the configuration setion values.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        private static void GetConfigSetionValues(out string username, out string password)
        {
            Hashtable remoteDataSource =
(Hashtable)WebConfigurationManager.GetSection("remoteDataAPI");
            username = (string)remoteDataSource["username"];
            password = (string)remoteDataSource["password"];
            string url = (string)remoteDataSource["url"];
        }
   

        [Fact]
        public void should_not_be_able_to_continue_if_the_employee_id_is_a_group()
        {
            // Mock out the context to run the action filter.
            var header = new Mock<HttpRequestHeaders>();
            
            var request = new Mock<HttpRequestMessage>();
            request.Setup(r => r.Headers).Returns(header.Object);

            var routeData = new RouteData(); //
            routeData.Values.Add("employeeId", "123");

            var actionExecutedContext = new Mock<HttpActionContext>();
            actionExecutedContext.SetupGet(c => c.Request).Returns(request.Object);

            var filter = new AuthenticateAttribute();

            filter.OnActionExecuting(actionExecutedContext.Object);

         

            // Assert
            //Assert.That(actionExecutedContext.Object.Result, Is.InstanceOfType(typeof(ContentResult)));
            //Assert.That((actionExecutedContext.Object.Result as ContentResult).Content, Is.EqualTo(filter.HtmlResultString));
        }






    }
}
