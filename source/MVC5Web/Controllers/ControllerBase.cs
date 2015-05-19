

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseWebController.cs" company="Megadonet">
//   Copyright (c) 2010-2014 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   a interface of data acccess repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MVC5Web.Controllers
{
     using DataServiceClient;
    using IronFramework.Utility;
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    /// <summary>
    /// a interface of data acccess repository.
    /// </summary>
    public class BaseWebController : Controller
    {
       #region Public WebApi client Methods

        /// <summary>
        /// Gets or sets the webapi URI.
        /// </summary>
        /// <value>
        /// The webapi URI.
        /// </value>
        public string webapiURI
        { 
            get; 
            set; 
        }

        [Dependency]
        public IRESTAPIWrapperClinet rESTAPIWrapperClinet { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="BaseWebController"/> class.
        /// </summary>
        public BaseWebController()
        {
            this.webapiURI=ServiceConfig.URI;
        }

        #region Wrap REST CRUD method API
        /// <summary>
        /// Clients the invoke HTTP post.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> ClientInvokeHttpPOST<TResult>(TResult model) where TResult : new()
        {
            return await rESTAPIWrapperClinet.ClientHttpPOST<TResult>(model);
        }

        /// <summary>
        /// Clients the invoke HTTP post.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="customURL">The custom URL.</param>
        /// <returns></returns>
        public async Task<bool> ClientInvokeHttpPOST<T, Query>(Query query, string customURL) where T : new()
        {
            return await rESTAPIWrapperClinet.ClientHttpPOST<T,Query>(query, customURL);
        }

        /// <summary>
        /// Clients the invoke HTTP post.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="customURL">The custom URL.</param>
        /// <param name="isawait">if set to <c>true</c> [isawait].</param>
        /// <returns></returns>
        public async Task<bool> ClientInvokeHttpPOST<T, Query>(Query query, string customURL, bool isawait) where T : new()
        {
            return await rESTAPIWrapperClinet.ClientHttpPOST<T, Query>(query, customURL, isawait);
        }

        /// <summary>
        /// Clients the invoke HTTP post.
        /// </summary>
        /// <typeparam name="ReturnObject">The type of the eturn object.</typeparam>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="customURL">The custom URL.</param>
        /// <returns></returns>
        public async Task<ReturnObject> ClientInvokeHttpPOST<ReturnObject, T, Query>(Query query, string customURL)
            where T : new()
            where ReturnObject : new()
        {
            return await rESTAPIWrapperClinet.ClientHttpPOST<ReturnObject, T, Query>(query, customURL);
        }

        /// <summary>
        /// Clients the HTTP get.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<TResult> ClientHTTPGet<TResult>(int id) where TResult : new()
        {
            return await rESTAPIWrapperClinet.ClientHTTPGet<TResult>(id);
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public async Task<TResult> ClientHTTPGetList<TResult, Query>(Query query) where TResult : new()
        {
            return await rESTAPIWrapperClinet.ClientHTTPGetList<TResult, Query>(query);
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="isAwait">if set to <c>true</c> [is await].</param>
        /// <returns></returns>
        public async Task<T> ClientHTTPGetList<T, Query>(Query query, bool isAwait) where T : new()
        {
            return await RESTAPIWrapperClinet.Instance().ClientHTTPGetList<T, Query>(query, isAwait);
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="partialURI">The partial URI.</param>
        /// <param name="query">The query.</param>
        /// <param name="isAwait">if set to <c>true</c> [is await].</param>
        /// <returns></returns>
        public async Task<T> ClientHTTPGetList<T, Query>(string partialURI, Query query, bool isAwait) where T : new()
        {
            return await RESTAPIWrapperClinet.Instance().ClientHTTPGetList<T, Query>(partialURI, query, isAwait);
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TQueryDto">The type of the query dto.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="partialURI">The partial URI.</param>
        /// <param name="query">The query.</param>
        /// <param name="isAwait">if set to <c>true</c> [is await].</param>
        /// <returns></returns>
        public async Task<T> ClientHTTPGetList<T, TQueryDto, Query>(string partialURI, Query query, bool isAwait) where T : new()
        {
            return await RESTAPIWrapperClinet.Instance().ClientHTTPGetList<T, TQueryDto, Query>(partialURI, query, isAwait);
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="partialURI">The partial URI.</param>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public async Task<T> ClientHTTPGetList<T, Query>(string partialURI, Query query) where T : new()
        {
            return await rESTAPIWrapperClinet.ClientHTTPGetList<T, Query>(query, partialURI);
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="queryString">The query string.</param>
        /// <returns></returns>
        public async Task<TResult> ClientHTTPGetList<TResult, Query>(string queryString) where TResult : new()
        {
            return await rESTAPIWrapperClinet.ClientHTTPGetList<TResult, Query>(queryString);
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="partialURI">The partial URI.</param>
        /// <param name="isawait">if set to <c>true</c> [isawait].</param>
        /// <returns></returns>
        public async Task<TResult> ClientHTTPGetList<TResult, Query>(string partialURI, bool isawait) where TResult : new()
        {
            return await rESTAPIWrapperClinet.ClientHTTPGetList<TResult, Query>(partialURI, isawait);
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="partialURI">The partial URI.</param>
        /// <param name="queryString">The query string.</param>
        /// <returns></returns>
        public async Task<TResult> ClientHTTPGetList<TResult, Query>(string partialURI, string queryString) where TResult : new()
        {
            return await rESTAPIWrapperClinet.ClientHTTPGetList<TResult, Query>(partialURI, queryString);
        }

        /// <summary>
        /// Clients the HTTP get list.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="partialURI">The partial URI.</param>
        /// <param name="queryString">The query string.</param>
        /// <returns></returns>
        public async Task<TResult> ClientHTTPGetList<TResult, Query>(string partialURI, string queryString, bool isawait) where TResult : new()
        {
            return await rESTAPIWrapperClinet.ClientHTTPGetList<TResult, Query>(partialURI, queryString, isawait);
        }

        /// <summary>
        /// Clients the HTTP get.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="customURL">The custom URL.</param>
        /// <returns></returns>
        public async Task<TResult> ClientHTTPGet<TResult>(int id, string customURL) where TResult : new()
        {
            return await rESTAPIWrapperClinet.ClientHTTPGet<TResult>(id, customURL);
        }

        /// <summary>
        /// Clients the HTTP put.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> ClientHTTPPut<T>(T model) where T : new()
        {
            return await rESTAPIWrapperClinet.ClientHTTPPut<T>(model);
        }


        /// <summary>
        /// Clients the HTTP put.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="model">The model.</param>
        /// <param name="customPartialUri">The custom partial URI.</param>
        /// <returns></returns>
        public async Task<bool> ClientHTTPPut<TResult, Query>(Query model, string customPartialUri)
        {
            return await rESTAPIWrapperClinet.ClientHTTPPut<TResult, Query>(model, customPartialUri);
        }

        /// <summary>
        /// Clients the HTTP put.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TQueryDto">The type of the query dto.</typeparam>
        /// <typeparam name="Query">The type of the uery.</typeparam>
        /// <param name="model">The model.</param>
        /// <param name="customPartialUri">The custom partial URI.</param>
        /// <returns></returns>
        public async Task<TResult> ClientHTTPPut<TResult, TQueryDto, Query>(Query model, string customPartialUri) where TResult : new()
        {
            return await rESTAPIWrapperClinet.ClientHTTPPut<TResult, TQueryDto, Query>(model, customPartialUri);
        }

        /// <summary>
        /// Clients the HTTP delete.
        /// </summary>
        /// <typeparam name="T">T name should include DTOs string</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> ClientHTTPDelete<T>(int id)
        {
            return await rESTAPIWrapperClinet.ClientHTTPDelete<T>(id);
        }

        /// <summary>
        /// Clients the HTTP delete.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="customPartialUri">The custom partial URI.</param>
        /// <returns></returns>
        public async Task<bool> ClientHTTPDelete<T>(int id, string customPartialUri)
        {
            return await rESTAPIWrapperClinet.ClientHTTPDelete<T>(id, customPartialUri);
        } 
        #endregion

        #endregion
    }


}

