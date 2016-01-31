using IronFramework.Common.Logging.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Tracing;

namespace WebApi2.App_Start
{
    public class LoggingTracer : ITraceWriter
    {
        private static readonly ILogger log = new Logger("LoggingTracer");

        public void Trace(HttpRequestMessage request, string category, TraceLevel level,
            Action<TraceRecord> traceAction)
        {
            TraceRecord rec = new TraceRecord(request, category, level);
            traceAction(rec);
            WriteTrace(rec);
        }

        protected void WriteTrace(TraceRecord rec)
        {
            var message = string.Format("{0};{1};{2}",
                rec.Operator, rec.Operation, rec.Message);
            //System.Diagnostics.Trace.WriteLine(message, rec.Category);
            log.TraceFormat("Category {0} - {1}", rec.Category,message);
        }
    }
}