// ***********************************************************************
// Assembly         : Net2Pager
// Author           : PeterLiu
// Created          : 07-19-2014
//
// Last Modified By : PeterLiu
// Last Modified On : 01-04-2007
// ***********************************************************************
// <copyright file="PagerDesigner.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.IO;

namespace DiyControl.Pager
{
    #region Net2Pager Control Designer
    /// <summary>
    /// <see cref="Net2Pager" /> 服务器控件设计器。
    /// </summary>
    /// <remarks>http://wintersun.cnblogs.com/</remarks>
    public class PagerDesigner : ControlDesigner
    {
        /// <summary>
        /// 初始化 PagerDesigner 的新实例。
        /// </summary>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public PagerDesigner()
        {
            //       this.ReadOnly = true;
        }
        /// <summary>
        /// The wb
        /// </summary>
        private Net2Pager wb;

        /// <summary>
        /// 获取用于在设计时表示关联控件的 HTML。
        /// </summary>
        /// <returns>用于在设计时表示控件的 HTML。</returns>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public override string GetDesignTimeHtml()
        {

            wb = (Net2Pager)Component;
            wb.RecordCount = 225;
            StringWriter sw = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            wb.RenderControl(writer);
            return sw.ToString();
        }

        /// <summary>
        /// 获取在呈现控件时遇到错误后在设计时为指定的异常显示的 HTML。
        /// </summary>
        /// <param name="e">要为其显示错误信息的异常。</param>
        /// <returns>设计时为指定的异常显示的 HTML。</returns>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        protected override string GetErrorDesignTimeHtml(Exception e)
        {
            string errorstr = "创建控件时出错：" + e.Message;
            return CreatePlaceHolderDesignTimeHtml(errorstr);
        }
    }
    #endregion
}
