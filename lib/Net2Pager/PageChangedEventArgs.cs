// ***********************************************************************
// Assembly         : Net2Pager
// Author           : PeterLiu
// Created          : 07-19-2014
//
// Last Modified By : PeterLiu
// Last Modified On : 01-19-2007
// ***********************************************************************
// <copyright file="PageChangedEventArgs.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace DiyControl.Pager
{
    #region PageChangedEventArgs Class
    /// <summary>
    /// 为 <see cref="Net2Pager" /> 控件的 <see cref="Net2Pager.PageChanged" /> 事件提供数据。无法继承此类。
    /// </summary>
    /// <remarks>当 <see cref="Net2Pager" /> 控件的页导航元素之一被单击或用户输入页索引提交时引发 <see cref="Net2Pager.PageChanged" /> 事件。
    /// <p>有关 PageChangedEventArgs 实例的初始属性值列表，请参阅 PageChangedEventArgs 构造函数。</p></remarks>
    public sealed class PageChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The _newpageindex
        /// </summary>
        private readonly int _newpageindex;

        /// <summary>
        /// 使用新页面索引初始化 PageChangedEventArgs 类的新实例。
        /// </summary>
        /// <param name="newPageIndex">用户从 <see cref="Net2Pager" /> 控件的页选择元素选定的或在页索引文本框中手工输入的页的索引。</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public PageChangedEventArgs(int newPageIndex)
        {
            this._newpageindex = newPageIndex;
        }

        /// <summary>
        /// 获取用户在 <see cref="Net2Pager" /> 控件的页选择元素中选定的或在页索引文本框中手工输入的页的索引。
        /// </summary>
        /// <value>用户在 <see cref="Net2Pager" /> 控件的页选择元素中选定的或在页索引文本框中输入的页的索引。</value>
        /// <example>
        /// 下面的示例显示如何使用 NewPageIndex 属性确定用户在 <see cref="Net2Pager" /> 控件的页选择元素中选定的或在页索引文本框中输入的页的索引。
        /// 该值然后用于设置要显示选定页的 Net2Pager 控件的 <see cref="Net2Pager.CurrentPageIndex" /> 属性，并对数据显示控件重新绑定数据。
        ///   <code><![CDATA[
        ///   <%@ Page Language="C#"%>
        ///   <%@ Import Namespace="System.Data"%>
        ///   <%@Import Namespace="System.Data.SqlClient"%>
        ///   <%@Import Namespace="System.Configuration"%>
        ///   <%@Register TagPrefix="Net2Pager" Namespace="Wuqi.Net2Pager" Assembly="aspnetpager"%>
        ///   <HTML>
        ///   <HEAD>
        ///   <TITLE>Welcome to Net2Pager.com </TITLE>
        ///   <script runat="server">
        /// SqlConnection conn;
        /// SqlCommand cmd;
        /// void Page_Load(object src,EventArgs e)
        /// {
        /// conn=new SqlConnection(ConfigurationSettings.AppSettings["ConnStr"]);
        /// if(!Page.IsPostBack)
        /// {
        /// cmd=new SqlCommand("GetNews",conn);
        /// cmd.CommandType=CommandType.StoredProcedure;
        /// cmd.Parameters.Add("@pageindex",1);
        /// cmd.Parameters.Add("@pagesize",1);
        /// cmd.Parameters.Add("@docount",true);
        /// conn.Open();
        /// pager.RecordCount=(int)cmd.ExecuteScalar();
        /// conn.Close();
        /// BindData();
        /// }
        /// }
        /// void BindData()
        /// {
        /// cmd=new SqlCommand("GetNews",conn);
        /// cmd.CommandType=CommandType.StoredProcedure;
        /// cmd.Parameters.Add("@pageindex",pager.CurrentPageIndex);
        /// cmd.Parameters.Add("@pagesize",pager.PageSize);
        /// cmd.Parameters.Add("@docount",false);
        /// conn.Open();
        /// dataGrid1.DataSource=cmd.ExecuteReader();
        /// dataGrid1.DataBind();
        /// conn.Close();
        /// }
        /// void ChangePage(object src,PageChangedEventArgs e)
        /// {
        /// pager.CurrentPageIndex=e.NewPageIndex;
        /// BindData();
        /// }
        ///   </script>
        ///   <meta http-equiv="Content-Language" content="zh-cn">
        ///   <meta http-equiv="content-type" content="text/html;charset=gb2312">
        ///   <META NAME="Generator" CONTENT="EditPlus">
        ///   <META NAME="Author" CONTENT="Net2Pager(yhaili@21cn.com)">
        ///   </HEAD>
        ///   <body>
        ///   <form runat="server" ID="Form1">
        ///   <asp:DataGrid id="dataGrid1" runat="server" />
        ///   <Net2Pager:Net2Pager id="pager"
        /// runat="server"
        /// PageSize="8"
        /// NumericButtonCount="8"
        /// ShowCustomInfoSection="before"
        /// ShowInputBox="always"
        /// CssClass="mypager"
        /// HorizontalAlign="center"
        /// OnPageChanged="ChangePage" />
        ///   </form>
        ///   </body>
        ///   </HTML>
        /// ]]>
        ///   </code>
        ///   <p>下面是该示例所用的Sql Server存储过程：</p>
        ///   <code>
        ///   <![CDATA[
        /// CREATE procedure GetNews
        /// (@pagesize int,
        /// @pageindex int,
        /// @docount bit)
        /// as
        /// set nocount on
        /// if(@docount=1)
        /// select count(id) from news
        /// else
        /// begin
        /// declare @indextable table(id int identity(1,1),nid int)
        /// declare @PageLowerBound int
        /// declare @PageUpperBound int
        /// set @PageLowerBound=(@pageindex-1)*@pagesize
        /// set @PageUpperBound=@PageLowerBound+@pagesize
        /// set rowcount @PageUpperBound
        /// insert into @indextable(nid) select id from news order by addtime desc
        /// select O.id,O.source,O.title,O.addtime from news O,@indextable t where O.id=t.nid
        /// and t.id>@PageLowerBound and t.id<=@PageUpperBound order by t.id
        /// end
        /// set nocount off
        /// GO
        /// ]]>
        ///   </code>
        ///   </example>
        /// <remarks>使用 NewPageIndex 属性确定用户在 <see cref="Net2Pager" /> 控件的页选择元素中选定的或在页索引文本框中输入的页的索引。
        /// 该值常用于设置要显示选定页的 Net2Pager 控件的 <see cref="Net2Pager.CurrentPageIndex" /> 属性。</remarks>
        public int NewPageIndex
        {
            get { return _newpageindex; }
        }
    }
    #endregion
}
