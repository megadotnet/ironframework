

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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using BusinessObject;

    /// <summary>
    /// a interface of data acccess repository.
    /// </summary>
    public class BaseWebController : Controller
    {
        #region Public Methods

        public async Task<bool> ClientInvokeHttpPOST<T>(T model) where T : new()
        {
            return await RESTAPIClinet.Instance().ClientInvokeHttpPOST<T>(model);
        }

        public async Task<T> ClientHTTPGet<T>(int id) where T:new()
        {
           return await RESTAPIClinet.Instance().ClientHTTPGet<T>(id);
        }

        public async Task<T> ClientHTTPGetList<T, Query>(Query query) where T : new()
        {
            return await RESTAPIClinet.Instance().ClientHTTPGetList<T, Query>(query);
        }

        public async Task<T> ClientHTTPGetList<T, Query>(string querystring) where T : new()
        {
            return await RESTAPIClinet.Instance().ClientHTTPGetList<T, Query>(querystring);
        }
        public async Task<bool>  ClientHTTPPut<T>(T model) where T : new()
        {
            return await RESTAPIClinet.Instance().ClientHTTPPut<T>(model);
        }

        public async Task<bool> ClientHTTPDelete<T>(int id)
        {
            return await RESTAPIClinet.Instance().ClientHTTPDelete<T>(id);
        }

        public async Task<bool> ClientHTTPPut<TResult, Query>(Query model, string customPartialUri)
        {
            return await RESTAPIClinet.Instance().ClientHTTPPut<TResult, Query>(model, customPartialUri);
        }
       
        #endregion
    }


}

