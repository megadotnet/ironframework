#region FileHeader
// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ExceptionHelper.cs" company="Megadotnet">
//    PetterLiu @ 2014-2018
//  </copyright>
//  <summary>
//    ExceptionHelper.cs  
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------
#endregion
namespace IronFramework.Utility.Exception
{
    using System;
    using System.Diagnostics;
    using Exception = System.Exception;

    /// <summary>
    /// The exception helper.
    /// </summary>
    public class ExceptionHelper
    {
        /// <summary>
        /// The try catch general exception with logger wrapper.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="log">
        /// The log.
        /// </param>
        public static void TryCatchGeneralExceptionWithLoggerWrapper(Action action, Trace log)
        {
            TryCatchGeneralExceptionWithLoggerWrapper(action, log, false);
        }

        /// <summary>
        /// Tries the catch general exception with logger wrapper.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="log">The log.</param>
        /// <param name="needThrowIt">if set to <c>true</c> [need throw it].</param>
        public static void TryCatchGeneralExceptionWithLoggerWrapper(Action action, Trace log, bool needThrowIt)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                
                Trace.Write(ex);
                if (needThrowIt)
                    throw;
            }
        }
    }
}
