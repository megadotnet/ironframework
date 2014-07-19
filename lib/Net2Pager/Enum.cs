// ***********************************************************************
// Assembly         : Net2Pager
// Author           : PeterLiu
// Created          : 07-19-2014
//
// Last Modified By : PeterLiu
// Last Modified On : 01-04-2007
// ***********************************************************************
// <copyright file="Enum.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace DiyControl.Pager
{
    #region ShowInputBox,ShowCustomInfoSection and PagingButtonType Enumerations
    /// <summary>
    /// 指定页索引输入文本框的显示方式，以便用户可以手工输入页索引。
    /// </summary>
    /// <remarks>http://wintersun.cnblogs.com/</remarks>
    public enum ShowInputBox : byte
    {
        /// <summary>
        /// 从不显示页索引输入文本框。
        /// </summary>
        Never,
        /// <summary>
        /// 自动，选择此项后可以用 <see cref="Net2Pager.ShowBoxThreshold" /> 可控制当总页数达到多少时自动显示页索引输入文本框。
        /// </summary>
        Auto,
        /// <summary>
        /// 总是显示页索引输入文本框。
        /// </summary>
        Always
    }


    /// <summary>
    /// 指定当前页索引和总页数信息的显示方式。
    /// </summary>
    /// <remarks>http://wintersun.cnblogs.com/</remarks>
    public enum ShowCustomInfoSection : byte
    {
        /// <summary>
        /// 不显示。
        /// </summary>
        Never,
        /// <summary>
        /// 显示在页导航元素之前。
        /// </summary>
        Left,
        /// <summary>
        /// 显示在页导航元素之后。
        /// </summary>
        Right
    }

    /// <summary>
    /// 指定页导航按钮的类型。
    /// </summary>
    /// <remarks>http://wintersun.cnblogs.com/</remarks>
    public enum PagingButtonType : byte
    {
        /// <summary>
        /// 使用文字按钮。
        /// </summary>
        Text,
        /// <summary>
        /// 使用图片按钮。
        /// </summary>
        Image
    }


    #endregion
}
