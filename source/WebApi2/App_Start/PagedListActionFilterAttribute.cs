using IronFramework.Utility.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WebApi2.Controllers
{
    /// <summary>
    /// PagedListActionFilterAttribute
    /// </summary>
    /// <example>
    /// <code>
    /// <![CDATA[  
    /// [HttpGet]
    ///[Route("api/Address/GetAync")]
    ///[PagedListActionFilter] 
    ///public async Task<PagedList<AddressDto>> GetAync([FromUri] int pageIndex, int pageSize)
    ///{
    ///    var index = Request.GetPageIndex();
    ///    var size = Request.GetPageSize();
    ///    return await _AddressBO.FindEntiesAsync(index, size);
    ///}
    /// ]]>
    /// </code>
    /// </example>
    /// <see cref="http://www.tomdupont.net/2015/04/paged-list-for-webapi.html"/>
    public class PagedListActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext); 
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            if (objectContent == null)
            { 
                return; 
            }
            var pagedList = objectContent.Value as IPagedList;
            if (pagedList == null)
            {
                return;
            }
            actionExecutedContext.Response.Headers.Add("X-Page-Index", pagedList.PageIndex.ToString(CultureInfo.InvariantCulture));
            actionExecutedContext.Response.Headers.Add("X-Page-Size", pagedList.PageSize.ToString(CultureInfo.InvariantCulture));
            actionExecutedContext.Response.Headers.Add("X-Total-Count", pagedList.TotalCount.ToString(CultureInfo.InvariantCulture));
            var listType = pagedList.GetType();
            actionExecutedContext.Response.Content = new ObjectContent(listType, pagedList, objectContent.Formatter);
        }
    }

    public static class RequestExtensions
    {
        public static int GetPageSize(this HttpRequestMessage requestMessage, int defaultSize = 5)
        {
            return GetIntFromQueryString(requestMessage, "pageSize", defaultSize);
        }
        public static int GetPageIndex(this HttpRequestMessage requestMessage, int defaultIndex = 0)
        {
            return GetIntFromQueryString(requestMessage, "pageIndex", defaultIndex);
        }
        public static int GetIntFromQueryString(this HttpRequestMessage requestMessage, string key, int defaultValue)
        {
            var pair = requestMessage.GetQueryNameValuePairs().FirstOrDefault(p => p.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase));
            if (!string.IsNullOrWhiteSpace(pair.Value))
            {
                int value;
                if (int.TryParse(pair.Value, out value))
                {
                    return value;
                }
            } 
            return defaultValue;
        }
    }
}