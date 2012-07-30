// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompressWhitespaceModule.cs" company="Megadotnet">
//    Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   CompressWhitespaceModule
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace IronFramework.Utility.Web.HttpModule
{
    using System.Web;

    /// <summary>
    /// CompressWhitespaceModule
    /// </summary>
    /// <remarks>Current only work with Asp.net web form</remarks>
    public class CompressWhitespaceModule : BaseHttpModule
    {
        /// <summary>
        /// The on begin request.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void OnBeginRequest(HttpContextBase context)
        {
            if (context.Request.RawUrl.Contains(".aspx"))
            {
                HttpRequestBase request = context.Request;
                string acceptEncoding = request.Headers["Accept-Encoding"];
                HttpResponseBase response = context.Response;
                if (!string.IsNullOrEmpty(acceptEncoding))
                {
                    acceptEncoding = acceptEncoding.ToUpperInvariant();
                    if (acceptEncoding.Contains("GZIP"))
                    {
                        response.Filter = new CompressWhitespaceFilter(context.Response.Filter, CompressOptions.GZip);
                        response.AppendHeader("Content-encoding", "gzip");
                    }
                    else if (acceptEncoding.Contains("DEFLATE"))
                    {
                        response.Filter = new CompressWhitespaceFilter(context.Response.Filter, CompressOptions.Deflate);
                        response.AppendHeader("Content-encoding", "deflate");
                    }
                }

                response.Cache.VaryByHeaders["Accept-Encoding"] = true;
            }
        }
    }
}