using IronFramework.Common.Logging.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Tracing;

namespace WebApi2.App_Start
{
    /// <summary>
    /// LoggingTracer
    /// </summary>
    public class LoggingTracer : ITraceWriter
    {
        /// <summary>
        /// ILogger
        /// </summary>
        private static readonly ILogger log = new Logger("LoggingTracer");

        /// <summary>
        /// Trace
        /// </summary>
        /// <param name="request"></param>
        /// <param name="category"></param>
        /// <param name="level"></param>
        /// <param name="traceAction"></param>
        public void Trace(HttpRequestMessage request, string category, TraceLevel level,
            Action<TraceRecord> traceAction)
        {
            TraceRecord rec = new TraceRecord(request, category, level);
            traceAction(rec);
            WriteTrace(rec);
        }

        /// <summary>
        /// WriteTrace
        /// </summary>
        /// <param name="rec"></param>
        protected void WriteTrace(TraceRecord rec)
        {
            var message = string.Format("{0};{1};{2}",
                rec.Operator, rec.Operation, rec.Message);
            //System.Diagnostics.Trace.WriteLine(message, rec.Category);
            log.TraceFormat("Category {0} - {1}", rec.Category,message);
        }
    }
}