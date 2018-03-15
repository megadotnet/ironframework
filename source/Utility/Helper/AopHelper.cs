// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AopHelper.cs" company="Megadotnet">
// Copyright (c) 2010-2018 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//  AopHelper
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace IronFramework.Utility.AopHelper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Web;

    /// <summary>
    ///AopHelper
    /// </summary>
    public class AopHelper
    {
       
        /// <summary>
        /// 等待执行的委托队列
        /// </summary>
        internal Action<Action> Chain = null;

        internal Delegate WorkDelegate;

        /// <summary>
        /// 最终执行会调用此方法
        /// </summary>
        /// <param name="work">待执行的方法</param>
        [DebuggerStepThrough]
        public void Do(Action work)
        {
            if (this.Chain == null)
            {
                work();
            }
            else
            {
                this.Chain(work);
            }
        }

        [DebuggerStepThrough]
        public TReturnType Return<TReturnType>(Func<TReturnType> work)
        {
            this.WorkDelegate = work;

            if (this.Chain == null)
            {
                return work();
            }
            else
            {
                TReturnType returnValue = default(TReturnType);
                this.Chain(() =>
                {
                    Func<TReturnType> workDelegate = WorkDelegate as Func<TReturnType>;
                    returnValue = workDelegate();
                });
                return returnValue;
            }
        }

        public static AopHelper Instance
        {
            [DebuggerStepThrough]
            get
            {
                return new AopHelper();
            }
        }

        /// <summary>
        /// 加入委托链
        /// </summary>
        /// <param name="newAspectDelegate">newAspectDelegate</param>
        /// <returns>AopHelper</returns>
        [DebuggerStepThrough]
        public AopHelper Combine(Action<Action> newAspectDelegate)
        {
            if (this.Chain == null)
            {
                this.Chain = newAspectDelegate;
            }
            else
            {
                Action<Action> existingChain = this.Chain;
                Action<Action> callAnother = (work) =>
                    existingChain(() => newAspectDelegate(work));
                this.Chain = callAnother;
            }

            return this;
        }

        /// <summary>
        /// 重试机制
        /// </summary>
        /// <param name="retryDuration">重试间隔</param>
        /// <param name="retryCount">重试次数</param>
        /// <param name="errorHandler">异常调用函数</param>
        /// <param name="retryFailed">重试最终失败调用函数</param>
        /// <param name="work">方法</param>
        public static void Retry(int retryDuration, int retryCount, Action<System.Exception> errorHandler, Action retryFailed, Action work)
        {
            int success = 0;
            do
            {
                try
                {
                    work();
                    success = 1;
                }
                catch (System.Exception x)
                {
                    success = 0;
                    errorHandler(x);
                    System.Threading.Thread.Sleep(retryDuration);
                }
            } while (retryCount-- > 0 && success == 0);
            if (success == 0)
            {
                retryFailed();
            }
        }
    }

    /// <summary>
    /// AopHelper扩展方法
    /// </summary>
    public static class AopHelperExtensions
    {
  
        static AopHelperExtensions()
        {

        }
        
        //控制各切片方法是否生效
        private static bool LogEnabled = true;
        private static bool CalcExecuteTimeEnabled = true;
        private static bool RetryEnabled = true;
        private static bool RetryWithParamEnabled = true;
        private static bool DelayEnabled = true;
        //控制各切片方法是否生效end

        /// <summary>
        /// 记日志
        /// </summary>
        /// <param name="aopHelper">aopHelper</param>
        /// <param name="msg">内容</param>
        /// <returns>aopHelper</returns>
        [DebuggerStepThrough]
        public static AopHelper Log(this AopHelper aopHelper, string msg)
        {
            if (!LogEnabled)
            {
                return aopHelper;
            }
            return aopHelper.Combine((work) =>
            {
                Trace.WriteLine(String.Format("{0}开始:{1}", msg, DateTime.Now));

                work();

                Trace.WriteLine(String.Format("{0}结束:{1}", msg, DateTime.Now));
            });
        }

        /// <summary>
        /// 计算方法执行时间
        /// </summary>
        /// <param name="aopHelper">aopHelper</param>
        /// <param name="method">方法名</param>
        /// <returns>aopHelper</returns>
        [DebuggerStepThrough]
        public static AopHelper CalcExecuteTime(this AopHelper aopHelper, string method)
        {
            if (!CalcExecuteTimeEnabled)
            {
                return aopHelper;
            }
            return aopHelper.Combine((work) =>
            {
                System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start(); //  开始监视代码运行时间
                work();
                stopwatch.Stop(); //  停止监视
                TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
                double hours = timespan.TotalHours; // 总小时
                double minutes = timespan.TotalMinutes;  // 总分钟
                double seconds = timespan.TotalSeconds;  //  总秒数
                double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数
                Trace.WriteLine(String.Format("{0}执行了{1}毫秒", method, milliseconds));
            });
        }

        /// <summary>
        /// 重试次数
        /// </summary>
        /// <param name="aspects">aopHelper</param>
        /// <param name="retryTimes">重试次数</param>
        /// <returns>aopHelper</returns>
        //[DebuggerStepThrough]
        public static AopHelper Retry(this AopHelper aopHelper, int retryTimes)
        {
            if (!RetryWithParamEnabled)
            {
                return aopHelper;
            }
            return aopHelper.Combine((work) =>
                AopHelper.Retry(1000, retryTimes, (error) => TryException(error), FailException, work));
        }

        /// <summary>
        /// 重试次数
        /// </summary>
        /// <param name="aspects">aopHelper</param>
        /// <param name="retryTimes">重试次数</param>
        /// <param name="retryTimes">重试间隔毫秒</param>
        /// <returns>aopHelper</returns>
        //[DebuggerStepThrough]
        public static AopHelper Retry(this AopHelper aopHelper, int retryTimes, int retryDuration)
        {
            if (!RetryEnabled)
            {
                return aopHelper;
            }
            return aopHelper.Combine((work) =>
                AopHelper.Retry(retryDuration, retryTimes, (error) => TryException(error), FailException, work));
        }

        public static void FailException()
        {
            Trace.WriteLine("数据库重试最终失败!");
        }

        public static void TryException(params object[] whatever)
        {
            Trace.WriteLine(String.Format("数据库操作异常：{0}", whatever));
        }


        public static void DoNothing()
        {
            Trace.WriteLine("最终还是彻底失败了!");
        }

        public static void DoNothing(params object[] whatever)
        {
            Trace.WriteLine(String.Format("异常了,原因：{0}", whatever));
        }

        /// <summary>
        /// 延迟几毫秒执行
        /// </summary>
        /// <param name="aopHelper">aopHelper</param>
        /// <param name="milliseconds">延迟几毫秒</param>
        /// <returns>aopHelper</returns>
        [DebuggerStepThrough]
        public static AopHelper Delay(this AopHelper aopHelper, int milliseconds)
        {
            if (!DelayEnabled)
            {
                return aopHelper;
            }
            return aopHelper.Combine((work) =>
            {
                System.Threading.Thread.Sleep(milliseconds);
                work();
            });
        }

        /// <summary>
        /// 参数不能为空
        /// </summary>
        /// <param name="aopHelper">aopHelper</param>
        /// <param name="args">参数</param>
        /// <returns>aopHelper</returns>
        [DebuggerStepThrough]
        public static AopHelper MustBeNonNull(this AopHelper aopHelper, params object[] args)
        {
            return aopHelper.Combine((work) =>
            {
                for (int i = 0; i < args.Length; i++)
                {
                    object arg = args[i];
                    if (arg == null)
                    {
                        throw new ArgumentException(string.Format("Parameter at index {0} is null", i));
                    }
                }
                work();
            });
        }

        /// <summary>
        /// 参数不能为空并且不能为默认值
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="aopHelper">aopHelper</param>
        /// <param name="args">参数</param>
        /// <returns>aopHelper</returns>
        public static AopHelper MustBeNonDefault<T>(this AopHelper aopHelper, params T[] args) where T : IComparable
        {
            return aopHelper.Combine((work) =>
            {
                T defaultvalue = default(T);
                for (int i = 0; i < args.Length; i++)
                {
                    T arg = args[i];
                    if (arg == null || arg.Equals(defaultvalue))
                    {
                        throw new ArgumentException(string.Format("Parameter at index {0} is null", i));
                    }
                }
                work();
            });
        }

        /// <summary>
        /// 满足条件系列时执行
        /// </summary>
        /// <param name="aopHelper">aopHelper</param>
        /// <param name="conditions">条件系列函数</param>
        /// <returns>aopHelper</returns>
        public static AopHelper WhenTrue(this AopHelper aopHelper, params Func<bool>[] conditions)
        {
            return aopHelper.Combine((work) =>
            {
                foreach (Func<bool> condition in conditions)
                {
                    if (!condition())
                    {
                        return;
                    }
                }
                work();
            });
        }

        /// <summary>
        /// 异步执行
        /// </summary>
        /// <param name="aopHelper">aopHelper</param>
        /// <param name="completeCallback">回调函数</param>
        /// <returns>aopHelper</returns>
        [DebuggerStepThrough]
        public static AopHelper RunAsync(this AopHelper aopHelper, Action completeCallback)
        {
            return aopHelper.Combine((work) => work.BeginInvoke(asyncresult =>
            {
                work.EndInvoke(asyncresult); completeCallback();
            }, null));
        }

        /// <summary>
        /// 异步执行
        /// </summary>
        /// <param name="aopHelper">aopHelper</param>
        /// <returns>aopHelper</returns>
        [DebuggerStepThrough]
        public static AopHelper RunAsync(this AopHelper aopHelper)
        {
            return aopHelper.Combine((work) => work.BeginInvoke(asyncresult =>
            {
                work.EndInvoke(asyncresult);
            }, null));
        }
    }

}
