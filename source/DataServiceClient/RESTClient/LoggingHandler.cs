using IronFramework.Common.Logging.Logger;
using IronFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataServiceClient
{
    /// <summary>
    /// LoggingHandler
    /// </summary>
    public class LoggingHandler : DelegatingHandler
    {
        /// <summary>
        ///     The log
        /// </summary>
        private static readonly ILogger log = new Logger("LoggingHandler");

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingHandler"/> class.
        /// </summary>
        /// <param name="innerHandler">负责处理 HTTP 响应消息的内部处理程序。</param>
        public LoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        /// <summary>
        /// 以异步操作发送 HTTP 请求到内部管理器以发送到服务器。
        /// </summary>
        /// <param name="request">要发送到服务器的 HTTP 请求消息。</param>
        /// <param name="cancellationToken">取消操作的取消标记。</param>
        /// <returns>
        /// 返回 <see cref="T:System.Threading.Tasks.Task`1" />。 表示异步操作的任务对象。
        /// </returns>
        protected override async Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                log.DebugFormat("{0}\t{1}\t{2}", request.RequestUri,
                    (int)response.StatusCode, response.Headers.Date);
            }
            return response;
        }


        /// <summary>
        /// 以异步操作发送 HTTP 请求到内部管理器以发送到服务器。
        /// </summary>
        /// <param name="request">要发送到服务器的 HTTP 请求消息。</param>
        /// <param name="cancellationToken">取消操作的取消标记。</param>
        /// <returns>
        /// 返回 <see cref="T:System.Threading.Tasks.Task`1" />。 表示异步操作的任务对象。
        /// </returns>
        //protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        //{
        //    log.Debug("Request请求:");
        //    log.Debug(request.ToString());
        //    if (request.Content != null)
        //    {
        //        log.Debug(await request.Content.ReadAsStringAsync());
        //    }


        //    var response = await base.SendAsync(request, cancellationToken);

        //    log.Debug("Response响应:");
        //    log.Debug(response.ToString());
        //    if (response.Content != null)
        //    {
        //        log.Debug(await response.Content.ReadAsStringAsync());
        //    }
           
        //    return response;
        //}
    }
}
