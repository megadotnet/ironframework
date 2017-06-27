using IronFramework.Common.Logging.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiThrottle;

namespace WebApi2.App_Start
{
    /// <summary>
    /// Class CommonTracingThrottleLogger.
    /// </summary>
    public class CommonTracingThrottleLogger : IThrottleLogger
    {
        /// <summary>
        /// The trace writer
        /// </summary>
        private static readonly ILogger traceWriter = new Logger("TracingThrottleLogger");

        /// <summary>
        /// Logs the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public void Log(ThrottleLogEntry entry)
        {

            traceWriter.InfoFormat("WebApiThrottle {0} Request {1} from {2} has been throttled (blocked), quota {3}/{4} exceeded by {5}.  Full Message {6}",
                    entry.LogDate, entry.RequestId, entry.ClientIp, entry.RateLimit, entry.RateLimitPeriod, entry.TotalRequests, entry.Request);

        }
    }
}