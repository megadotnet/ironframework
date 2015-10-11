

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Megadonet">
//   Copyright (c) 2010-2014 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   a interface of data acccess repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApi2.Controllers
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

    /// <summary>
    /// a interface of data acccess repository.
    /// </summary>
    //[Authenticate]
    public class BaseWebAPIController : ApiController
    {
        #region Public Methods

       
        #endregion
    }

    /// <summary>
    /// ValidateModelAttribute
    /// </summary>
    /// <seealso cref="http://www.asp.net/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api"/>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }

}

