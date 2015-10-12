using DataServiceClient;
using IronFramework.Common.Config;
using IronFramework.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xunit;

namespace WebApi2.Tests
{
    public class WebAPIAuthTesting
    {
        private IRESTAPIWrapperClinet restclient = new RESTAPIWrapperClinet();

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

                var postmodel = new OurModel { CityShortName = "文山", IcaoCode = "ZPPP" };

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
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string date = DateTime.UtcNow.ToString("u");
                client.DefaultRequestHeaders.Add("Timestamp", date);

                //string token=CreateToken()
                // HTTP GET
                string uri = "/api/Values/PostCity";
                string methodType = "POST";
                var postmodel = new OurModel { CityShortName = "文山", IcaoCode = "ZPPP" };

                string querystring = restclient.GetQueryString(postmodel, null);

                string message = string.Join("\n", methodType, date, uri.ToLower(), querystring);
                string token = VerifyTransactionSN.ComputeHash(SecurityConfig.Password, message);
                Console.WriteLine(token);

                client.DefaultRequestHeaders.Add("Authentication", string.Format("{0}:{1}", SecurityConfig.Password, token));

                string routingUrl = uri + "?" + querystring;



                var response = await client.PostAsJsonAsync(uri, postmodel);
                Assert.True(response.IsSuccessStatusCode);
            };

        }



        public class OurModel
        {
            public string IcaoCode { get; set; }
            public string CityShortName { get; set; }
        }
    }
}
