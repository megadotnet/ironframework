using IronFramework.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessObject
{
    public class RESTAPIClinet
    {
        /// <summary>
        /// Clients the invoke HTTP post.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> ClientInvokeHttpPOST<T>(T model)
        {
            using (var client = new HttpClient())
            {
                PrepareTargetSite(client);

                // HTTP POST
                string entityname = typeof(T).Name;
                entityname = entityname.Substring(0, entityname.IndexOf("Dto"));
                string routingUrl = "api/" + entityname;

                HttpResponseMessage response = await client.PostAsJsonAsync(routingUrl, model);
                return response.IsSuccessStatusCode;
            }

        }

        private static void PrepareTargetSite(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:3956/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Clients the HTTP put.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> ClientHTTPPut<T>(T model)
        {
            using (var client = new HttpClient())
            {
                PrepareTargetSite(client);

                // HTTP PUT
                string entityname = typeof(T).Name;
                entityname = entityname.Substring(0, entityname.IndexOf("Dto"));

                string routingUrl = "api/" + entityname;

                HttpResponseMessage response = await client.PutAsJsonAsync(routingUrl, model);
                return response.IsSuccessStatusCode;
            }
        }


        /// <summary>
        /// Clients the HTTP delete.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> ClientHTTPDelete<T>(int id)
        {
            using (var client = new HttpClient())
            {
                PrepareTargetSite(client);

                // HTTP DELETE
                string entityname = typeof(T).Name;
                entityname = entityname.Substring(0, entityname.IndexOf("Dto"));
                string routingUrl = string.Format("api/{0}/{1}", entityname, id);

                HttpResponseMessage response = await client.DeleteAsync(routingUrl);
                return response.IsSuccessStatusCode;
            }
        }


        /// <summary>
        /// Clients the HTTP get.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<T> ClientHTTPGet<T>(int id) where T:new()
        {
            using (var client = new HttpClient())
            {
                PrepareTargetSite(client);

                string entityname = typeof(T).Name;
                entityname=entityname.Substring(0,entityname.IndexOf("Dto"));
                string requestURI = string.Format("api/{0}/{1}", entityname, id);
                HttpResponseMessage response = await client.GetAsync(requestURI);
                if (response.IsSuccessStatusCode)
                {
                    T product = await response.Content.ReadAsAsync<T>();
                    return product;
                }

                return new T();
            }
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public async Task<T> ClientHTTPGetList<T, Query>(Query query) where T : new()
        {
            using (var client = new HttpClient())
            {
                PrepareTargetSite(client);

                string entityname = typeof(Query).Name;
                entityname = entityname.Substring(0, entityname.IndexOf("Dto"));

                string querystring = GetQueryString(query);

                //?pageindex=1&pagesize=10
                HttpResponseMessage response = await client.GetAsync(string.Format("api/{0}/?{1}", entityname, querystring));
                if (response.IsSuccessStatusCode)
                {
                    T product = await response.Content.ReadAsAsync<T>();
                    return product;
                }

                return new T();
            }
        }

        /// <summary>
        /// Gets the query string.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        private string GetQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null && p.CustomAttributes.All(attc => attc.AttributeType != typeof(KeyAttribute))
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }



        /// <summary>
        /// Instances this instance.
        /// </summary>
        /// <returns></returns>
        public static RESTAPIClinet Instance()
        {
            return Singleton.GetInstance<RESTAPIClinet>();
        }

    }
}
