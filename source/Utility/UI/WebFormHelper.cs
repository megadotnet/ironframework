// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebFormHelper.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   WebFormHelper extention method
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility.UI
{
    using System;
    using System.Web.UI;

    /// <summary>
    /// WebFormHelper extention method
    /// </summary>
    public static class WebFormHelper
    {
        #region Public Methods

        /// <summary>
        /// Strong type data bind for web form
        /// </summary>
        /// <typeparam name="TEntity">
        /// Entity
        /// </typeparam>
        /// <param name="page">
        /// system.web.ui.page
        /// </param>
        /// <param name="func">
        /// func
        /// </param>
        /// <returns>
        /// specific value
        /// </returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///  <%#this.Eval2<BusinessEntiies.Employee>(_ => _.EmployeeID)%>
        /// ]]>
        /// </code>
        /// </example>
        public static object Eval2<TEntity>(this Page page, Func<TEntity, object> func)
        {
            return ExpHelper(page, func);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The exp helper.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="func">
        /// The func.
        /// </param>
        /// <typeparam name="TEntity">
        /// </typeparam>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <returns>
        /// The exp helper.
        /// </returns>
        private static object ExpHelper<TEntity, TResult>(Page page, Func<TEntity, TResult> func)
        {
            object itm = page.GetDataItem();
            return func((TEntity)itm);
        }

        #endregion
    }
}