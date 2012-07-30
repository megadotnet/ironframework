// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveServerInfoModule.cs" company="Megadotnet">
//    Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   RemoveServerInfoModule
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace IronFramework.Utility.Web.HttpModule
{
    using System.Collections.Specialized;
    using System.Web;

    /// <summary>
    /// RemoveServerInfoModule
    /// </summary>
    public class RemoveServerInfoModule : BaseHttpModule
    {
        /// <summary>
        /// Called when [pre send request headers].
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void OnPreSendRequestHeaders(HttpContextBase context)
        {
            if (null != context && null != context.Request 
                && !context.Request.IsLocal && null != context.Response)
            {
                NameValueCollection headers = context.Response.Headers;
                if (null != headers)
                {
                    headers.Remove("Server");
                }
            }
        }
    }
}