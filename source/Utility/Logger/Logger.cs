#region FileHeader

// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Logger.cs" company="RuiLi AirLine">
//    RuiLi AirLine @ 2014
//  </copyright>
//  <summary>
//    Logger.cs  2014 08 21 14:58
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Logging;

namespace IronFramework.Utility
{
    /// <summary>
    /// The logger.
    /// </summary>
    public class Logger : ILogger
    {
        /// <summary>
        /// The _log.
        /// </summary>
        private readonly ILog _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        public Logger(Type type)
        {
            _log = LogManager.GetLogger(type);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="typestr">
        /// The typestr.
        /// </param>
        public Logger(string typestr)
        {
            _log = LogManager.GetLogger(typestr);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        public Logger()
        {
            _log = LogManager.GetCurrentClassLogger();
        }


        /// <summary>
        /// Gets a value indicating whether is trace enabled.
        /// </summary>
        public bool IsTraceEnabled
        {
            get
            {
                return _log.IsTraceEnabled;
            }
        }

        /// <summary>
        /// Gets a value indicating whether is debug enabled.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool IsDebugEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets a value indicating whether is error enabled.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool IsErrorEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets a value indicating whether is fatal enabled.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool IsFatalEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets a value indicating whether is info enabled.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool IsInfoEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets a value indicating whether is warn enabled.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool IsWarnEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The trace.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Trace(object message)
        {
            _log.Trace(message);
        }

        /// <summary>
        /// The trace.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public void Trace(object message, Exception exception)
        {
            _log.Trace(message, exception);
        }

        /// <summary>
        /// The trace format.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void TraceFormat(string format, params object[] args)
        {
            _log.TraceFormat(format, args);
        }

        /// <summary>
        /// The trace format.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void TraceFormat(string format, Exception exception, params object[] args)
        {
            _log.TraceFormat(format, exception, args);
        }

        /// <summary>
        /// The trace format.
        /// </summary>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void TraceFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            _log.TraceFormat(format, format, args);
        }

        /// <summary>
        /// The trace format.
        /// </summary>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void TraceFormat(
            IFormatProvider formatProvider, 
            string format, 
            Exception exception, 
            params object[] args)
        {
            _log.TraceFormat(formatProvider, format, args);
        }

        /// <summary>
        /// The debug.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Debug(object message)
        {
            _log.Debug(message);
        }

        /// <summary>
        /// The debug.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public void Debug(object message, Exception exception)
        {
            _log.Debug(message, exception);
        }

        /// <summary>
        /// The debug format.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void DebugFormat(string format, params object[] args)
        {
            _log.DebugFormat(format, args);
        }

        /// <summary>
        /// The debug format.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void DebugFormat(string format, Exception exception, params object[] args)
        {
            _log.DebugFormat(format, exception, args);
        }

        /// <summary>
        /// The debug format.
        /// </summary>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            _log.DebugFormat(format, format, args);
        }

        /// <summary>
        /// The debug format.
        /// </summary>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void DebugFormat(
            IFormatProvider formatProvider, 
            string format, 
            Exception exception, 
            params object[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The info.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Info(object message)
        {
            _log.Info(message);
        }

        /// <summary>
        /// The info.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public void Info(object message, Exception exception)
        {
            _log.Info(message, exception);
        }

        /// <summary>
        /// The info format.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void InfoFormat(string format, params object[] args)
        {
            _log.InfoFormat(format, args);
        }

        /// <summary>
        /// The info format.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void InfoFormat(string format, Exception exception, params object[] args)
        {
            _log.InfoFormat(format ,exception, args);
        }

        /// <summary>
        /// The info format.
        /// </summary>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            _log.InfoFormat(formatProvider, format, args);
        }

        /// <summary>
        /// The info format.
        /// </summary>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void InfoFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            _log.InfoFormat(format, exception, args);
        }

        /// <summary>
        /// The warn.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Warn(object message)
        {
            _log.Warn(message);
        }

        /// <summary>
        /// The warn.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public void Warn(object message, Exception exception)
        {
            _log.Warn(message, exception);
        }

        /// <summary>
        /// The warn format.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void WarnFormat(string format, params object[] args)
        {
            _log.WarnFormat(format, args);
        }

        /// <summary>
        /// The warn format.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void WarnFormat(string format, Exception exception, params object[] args)
        {
            _log.WarnFormat(format,exception, args);
        }

        /// <summary>
        /// The warn format.
        /// </summary>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The warn format.
        /// </summary>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void WarnFormat(IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Error(object message)
        {
            _log.Error(message);
            //MailHelper.SendMail(MailConfig.FromMail, MailConfig.DefaultTo, MailConfig.Password, "Error Logging from MessageCenter", message.ToString());
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public void Error(object message, Exception exception)
        {
            _log.Error(message, exception);
        }

        /// <summary>
        /// The error format.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void ErrorFormat(string format, params object[] args)
        {
            _log.ErrorFormat(format, args);
        }

        /// <summary>
        /// The error format.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void ErrorFormat(string format, Exception exception, params object[] args)
        {
            _log.ErrorFormat(format, exception, args);
        }

        /// <summary>
        /// The error format.
        /// </summary>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The error format.
        /// </summary>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void ErrorFormat(
            IFormatProvider formatProvider, 
            string format, 
            Exception exception, 
            params object[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The fatal.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void Fatal(object message)
        {
            _log.Fatal(message);
        }

        /// <summary>
        /// The fatal.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public void Fatal(object message, Exception exception)
        {
            _log.Fatal(message, exception);
        }

        /// <summary>
        /// The fatal format.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void FatalFormat(string format, params object[] args)
        {
            _log.FatalFormat(format, args);
        }

        /// <summary>
        /// The fatal format.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void FatalFormat(string format, Exception exception, params object[] args)
        {
            _log.FatalFormat(format, exception,args);
        }

        /// <summary>
        /// The fatal format.
        /// </summary>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The fatal format.
        /// </summary>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void FatalFormat(
            IFormatProvider formatProvider, 
            string format, 
            Exception exception, 
            params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}