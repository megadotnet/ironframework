using IronFramework.Common.Logging.Logger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace WebApi2.App_Start
{
/// <summary>
    /// ApplicationAuthenticationHandler
    /// </summary>
    /// <seealso cref="http://www.tuicool.com/articles/goto?id=7FF7zy"/>
    public class ApplicationAuthenticationHandler : DelegatingHandler
    {
        // Http Response Messages
        /// <summary>
        /// The invalid token
        /// </summary>
        private static readonly string InvalidToken = "Invalid Authorization-Token无效验证";
        /// <summary>
        /// The missing token
        /// </summary>
        private static readonly string MissingToken = "Missing Authorization-Token缺少验证标识";

        /// <summary>
        /// The log
        /// </summary>
        private static readonly ILogger log = new Logger("ApplicationAuthenticationHandler");

        /// <summary>
        /// The HTT p_ heade r_ aut h_ keyname
        /// </summary>
        private static readonly string HTTP_HEADER_AUTH_KEYNAME =
            (string)(((Hashtable)WebConfigurationManager.GetSection("AuthenticationHandlerConfig"))["keyname"]);

        /// <summary>
        /// 以异步操作发送 HTTP 请求到内部管理器以发送到服务器。
        /// </summary>
        /// <param name="request">要发送到服务器的 HTTP 请求消息。</param>
        /// <param name="cancellationToken">取消操作的取消标记。</param>
        /// <returns>
        /// 返回 <see cref="T:System.Threading.Tasks.Task`1" />。 表示异步操作的任务对象。
        /// </returns>
        /// <example><code>
        /// <![CDATA[
        /// User-Agent: Fiddler
        /// 
        ///Host: localhost:44300
        ///X-MonsterAppApiKey: MosterIPhoneX123:ThisMonsterIsPersist
        /// ]]>
        /// </code>
        /// </example>
        protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            // Write your Authentication code here
            IEnumerable<string> monsterApiKeyHeaderValues = null;

            // Checking the Header values
            if (request.Headers.TryGetValues(HTTP_HEADER_AUTH_KEYNAME, out monsterApiKeyHeaderValues))
            {
                string[] apiKeyHeaderValue = monsterApiKeyHeaderValues.First().Split(':');

                // Validating header value must have both APP ID & APP key
                if (apiKeyHeaderValue.Length == 2)
                {
                    // Code logic after authenciate the application.
                    var appID = apiKeyHeaderValue[0];
                    var AppKey = apiKeyHeaderValue[1];

                    if (Check(appID, AppKey))
                    {
                        var userNameClaim = new Claim(ClaimTypes.Name, appID);
                        var identity = new ClaimsIdentity(new[] { userNameClaim }, "MonsterAppApiKey");
                        var principal = new ClaimsPrincipal(identity);
                        Thread.CurrentPrincipal = principal;

                        if (System.Web.HttpContext.Current != null)
                        {
                            System.Web.HttpContext.Current.User = principal;
                        }
                    }
                    else
                    {
                        // Web request cancel reason APP key is NULL
                        return await requestCancel(request, cancellationToken, InvalidToken);
                    }
                }
                else
                {
                    // Web request cancel reason missing APP key or APP ID
                    return await requestCancel(request, cancellationToken, MissingToken);
                }
            }
            else
            {
                // Web request cancel reason APP key missing all parameters
                return await requestCancel(request, cancellationToken, MissingToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// Requests the cancel.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        private System.Threading.Tasks.Task<HttpResponseMessage> requestCancel(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken, string message)
        {
            CancellationTokenSource _tokenSource = new CancellationTokenSource();
            cancellationToken = _tokenSource.Token;
            _tokenSource.Cancel();
            HttpResponseMessage response = new HttpResponseMessage();

            response = request.CreateResponse(HttpStatusCode.BadRequest);
            response.Content = new StringContent(message);
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                return response;
            });
        }

        /// <summary>
        /// 接口校验用户名密码
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="password_str"></param>
        /// <returns></returns>
        public bool Check(string user_id, string password_str)
        {

            bool isAuthRequest = false;

            if ((!string.IsNullOrEmpty(user_id)) && (!string.IsNullOrEmpty(password_str)))
            {
                //You may store the username and password to database
                if (user_id == "SystemUser" && password_str == "MUDuoRc612/mHpsVmidUdNDyqfBAylVPwD48hE21I5A=")
                {
                    NLogLogger(1);

                    log.InfoFormat("Check {0}",user_id);
                    isAuthRequest = true;
                }

            }
            return isAuthRequest;
        }

        /// <summary>
        /// ns the log logger.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <see cref="http://blog.evizija.si/rest-web-api-logging-using-nlog/"/>
        private void NLogLogger(int? userId)
        {
            if (userId != null)
            {
                NLog.MappedDiagnosticsContext.Set("user_id", userId.ToString());
            }
        }
    }
}