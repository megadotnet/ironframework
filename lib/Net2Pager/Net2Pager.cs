// ***********************************************************************
// Assembly         : Net2Pager
// Author           : PeterLiu
// Created          : 07-19-2014
//
// Last Modified By : PeterLiu
// Last Modified On : 01-19-2007
// ***********************************************************************
// <copyright file="Net2Pager.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region 引用
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
#endregion
namespace DiyControl.Pager
{
    #region Net2Pager Server Control

    #region 控件说明及示例
    /// <summary>
    /// 用于ASP.NET Web应用程序中对数据进行分页的的服务器控件。
    /// </summary>
    /// <example>以下示例说明如何用Net2Pager对GridView进行分页。
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
    /// pager.CustomInfoText="记录总数：<font color=\"blue\"><b>"+pager.RecordCount.ToString()+"</b></font>";
    /// pager.CustomInfoText+=" 总页数：<font color=\"blue\"><b>"+pager.PageCount.ToString()+"</b></font>";
    /// pager.CustomInfoText+=" 当前页：<font color=\"red\"><b>"+pager.CurrentPageIndex.ToString()+"</b></font>";
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
    ///   <asp:GridView id="dataGrid1" runat="server" />
    ///   <Net2Pager:Net2Pager id="pager"
    /// runat="server"
    /// PageSize="8"
    /// NumericButtonCount="8"
    /// ShowCustomInfoSection="left"
    /// PagingButtonSpacing="0"
    /// ShowInputBox="always"
    /// CssClass="mypager"
    /// HorizontalAlign="right"
    /// OnPageChanged="ChangePage"
    /// SubmitButtonText="转到"
    /// NumericButtonTextFormatString="[{0}]"/>
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
    ///   </code></example>
    /// <remarks>不同于GridGrid控件，Net2Pager分页控件本身并不显示任何数据，而只显示页导航元素，数据在页面上的显示方式与该控件无关。该控件可以为GridView、DataList、Repeater以及自定义控件进行分页，配合Sql存储过程，分页性能较使用GridView分页有明显提升，尤其是当数据量大时性能可提升数倍！
    /// <p>要使用 Net2Pager 分页控件，必须最少指定它的 <see cref="RecordCount" /> 属性，指定并编写 <see cref="PageChanged" /> 事件的处理程序。
    /// <see cref="RecordCount" /> 属性指定要分页的所有数据的总项数，若未指定该值或该值小于等于 <see cref="PageSize" /> ，则Net2Pager控件不会显示任何内容。
    /// 若未指定并编写 <see cref="PageChanged" /> 事件处理程序，则当用户点击页导航元素或在页索引文本框中手式输入页索引并提交时Net2Pager不会跳转到指定的页。
    /// Net2Pager控件的分页方法和GridView基本相同，即在它的 <see cref="PageChanged" /> 事件处理程序中将传递事件数据的 <see cref="PageChangedEventArgs" /> 的 <see cref="PageChangedEventArgs.NewPageIndex" />值赋给 Net2Pager的 <see cref="CurrentPageIndex" />属性，然后重新将新的数据与数据显示控件绑定。 </p></remarks>
    [DefaultProperty("PageSize")]
    [DefaultEvent("PageChanged")]
    [ParseChildren(false)]
    [PersistChildren(false)]
    [Description("专用于ASP.Net2.0Web应用程序的分页控件")]
    [Designer(typeof(PagerDesigner))]
    [ToolboxData("<{0}:Net2Pager runat=server></{0}:Net2Pager>")]
    public class Net2Pager : Panel, INamingContainer, IPostBackEventHandler, IPostBackDataHandler
    {
        /// <summary>
        /// The CSS class name
        /// </summary>
        private string cssClassName;
        /// <summary>
        /// The input page index
        /// </summary>
        private string inputPageIndex;

        #region Properties

        #region Navigation Buttons

        /// <summary>
        /// 获取或设置一个值，该值批示当鼠标指针悬停在导航按钮上时是否显示工具提示。
        /// </summary>
        /// <value><c>true</c> if [show navigation tool tip]; otherwise, <c>false</c>.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("导航按钮"),
            DefaultValue(true),
            Description("指定当鼠标停留在导航按钮上时，是否显示工具提示")]
        public bool ShowNavigationToolTip
        {
            get
            {
                object obj = ViewState["ShowNavigationToolTip"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                ViewState["ShowNavigationToolTip"] = value;
            }
        }

        /// <summary>
        /// 获取或设置导航按钮工具提示文本的格式。
        /// </summary>
        /// <value>The navigation tool tip text format string.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("导航按钮"),
            DefaultValue("转到第{0}页"),
            Description("页导航按钮工具提示文本的格式")]
        public string NavigationToolTipTextFormatString
        {
            get
            {
                object obj = ViewState["NavigationToolTipTextFormatString"];
                return (obj == null) ? "转到第{0}页" : (string)obj;
            }
            set
            {
                string tip = value;
                if (tip.Trim().Length < 1 && tip.IndexOf("{0}") < 0)
                    tip = "{0}";
                ViewState["NavigationToolTipTextFormatString"] = tip;
            }
        }

        #region 获取或设置一个值，该值指示是否将页索引按钮用中文数字代替

        /// <summary>
        /// 获取或设置一个值，该值指示是否将页索引按钮用中文数字代替。
        /// </summary>
        /// <value><c>true</c> if [chinese page index]; otherwise, <c>false</c>.</value>
        /// <remarks>将该值设为true并且未使用图片按钮时，页索引按钮中的数值1、2、3等将会被中文字符一、二、三等代替。</remarks>
        [Browsable(true),
            Category("导航按钮"),
            DefaultValue(false),
            Description("是否将页索引数值按钮用中文数字一、二、三等代替")]
        public bool ChinesePageIndex
        {
            get
            {
                object obj = ViewState["ChinesePageIndex"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                ViewState["ChinesePageIndex"] = value;
            }
        }

        #endregion


        /// <summary>
        /// 获取或设置页索引数值导航按钮上文字的显示格式。
        /// </summary>
        /// <value>字符串，指定页索引数值按钮上文字的显示格式，默认值为<see cref="String.Empty" />，即未设置该属性。</value>
        /// <remarks>使用NumericButtonTextFormatString属性指定页索引数值按钮的显示格式，如未设置该值时索引按钮文本将会是：1 2 3 ...，设置该值将改变索引按钮文本的显示格式，
        /// 如将该值设为“[{0}]”则索引文本会显示为：[1] [2] [3] ...，将该值设为“-{0}-”则会使索引文本变为：-1- -2- -3- ...。</remarks>
        [Browsable(true),
            DefaultValue(""),
            Category("导航按钮"),
            Description("页索引数值按钮上文字的显示格式")]
        public string NumericButtonTextFormatString
        {
            get
            {
                object obj = ViewState["NumericButtonTextFormatString"];
                return (obj == null) ? String.Empty : (string)obj;
            }
            set
            {
                ViewState["NumericButtonTextFormatString"] = value;
            }
        }

        /// <summary>
        /// 获取或设置分页导航按钮的类型，即使用文字还是图片。
        /// </summary>
        /// <value>The type of the paging button.</value>
        /// <example>
        /// 以下代码片段示例如果使用图片按钮：
        ///   <p>
        ///   <code><![CDATA[
        ///   <Net2Pager:Net2Pager runat="server"
        /// id="pager1"
        /// OnPageChanged="ChangePage"
        /// PagingButtonType="image"
        /// ImagePath="images"
        /// ButtonImageNameExtension="n"
        /// DisabledButtonImageNameExtension="g"
        /// ButtonImageExtension="gif"
        /// CpiButtonImageNameExtension="r"
        /// PagingButtonSpacing=5/>
        /// ]]>
        ///   </code>
        ///   </p>
        ///   </example>
        /// <remarks>要使用图片按钮，您需要准备以下图片：从0到9的十个数值图片（当ShowPageIndex设为true时），第一页、上一页、下一页、最后一页及更多页（...）五个按钮图片（当ShowFirstLast及ShowPrevNext都设为true时），
        /// 若需要使当前页索引的数值按钮不同于别的页索引数值按钮，则还需准备当前页索引的按钮图片；
        /// 若需要使已禁用的第一页、上一页、下一页及最后一页按钮图片不同于正常的按钮图片，则还需准备这四个按钮在禁用状态下的图片；
        /// <p><b>图片文件的命名规则如下：</b></p>
        /// <p>从0到9十张数值按钮图片必须命名为“数值+ButtonImageNameExtension+ButtonImageExtension”，其中的ButtonImageNameExtension可以不用设置，
        /// ButtonImageExtension是图片文件的后缀名，如 .gif或 .jpg等可以在浏览器中显示的任何图片文件类型。如页索引“1”的图片文件可命名为“1.gif”或“1.jpg”，
        /// 当您有两套或更多套图片文件时，可以通过指定ButtonImageNameExtension属性值来区分不同套的图片，如第一套图片可以不用设ButtonImageNameExtension，则图片文件名类似于“1.gif”、“2.gif”等等，而第二套图片则设置ButtonImageNameExtension为“f”，图片文件名类似于“1f.gif”，“2f.gif”等等。</p>
        /// <p>第一页按钮的图片文件名以“first”开头，上一页按钮图片名以“prev”开头，下一页按钮图片名以“next”开头，最后一页按钮图片名以“last”开头，更多页按钮图片名以“more”开头，是否使用ButtonImageNameExtension取决于数值按钮的设置及是否有更多套图片。</p></remarks>
        [Browsable(true),
            DefaultValue(PagingButtonType.Text),
            Category("导航按钮"),
            Description("分页导航按钮的类型，是使用文字还是图片")]
        public PagingButtonType PagingButtonType
        {
            get
            {
                object obj = ViewState["PagingButtonType"];
                return (obj == null) ? PagingButtonType.Text : (PagingButtonType)obj;
            }
            set
            {
                ViewState["PagingButtonType"] = value;
            }
        }

        /// <summary>
        /// 获取或设置页导航数值按钮的类型，该值仅当PagingButtonType设为Image时才有效。
        /// </summary>
        /// <value>The type of the numeric button.</value>
        /// <remarks>当您将PagingButtonType设为Image当又不想让页索引数值按钮使用图片时，可以将该值设为Text，这会使页索引数据按钮使用文本而不是图片按钮。</remarks>
        [Browsable(true),
            DefaultValue(PagingButtonType.Text),
            Category("导航按钮"),
            Description("页导航数值按钮的类型")]
        public PagingButtonType NumericButtonType
        {
            get
            {
                object obj = ViewState["NumericButtonType"];
                return (obj == null) ? PagingButtonType : (PagingButtonType)obj;
            }
            set
            {
                ViewState["NumericButtonType"] = value;
            }
        }

        /// <summary>
        /// 获取或设置第一页、上一页、下一页和最后一页按钮的类型，该值仅当PagingButtonType设为Image时才有效。
        /// </summary>
        /// <value>The type of the navigation button.</value>
        /// <remarks>当您将PagingButtonType设为Image但又不想让第一页、下一页、下一页和最后一页按钮使用图片，则可以将该值设为Text，这会使前面的四个按钮使用文本而不是图片按钮。</remarks>
        [Browsable(true),
            Category("导航按钮"),
            DefaultValue(PagingButtonType.Text),
            Description("第一页、上一页、下一页和最后一页按钮的类型")]
        public PagingButtonType NavigationButtonType
        {
            get
            {
                object obj = ViewState["NavigationButtonType"];
                return (obj == null) ? PagingButtonType : (PagingButtonType)obj;
            }
            set
            {
                ViewState["NavigationButtonType"] = value;
            }
        }

        /// <summary>
        /// 获取或设置“更多页”（...）按钮的类型，该值仅当PagingButtonType设为Image时才有效。
        /// </summary>
        /// <value>The type of the more button.</value>
        /// <remarks>当您将PagingButtonType设为Image但又不想让更多页（...）按钮使用图片时，可以将此值设为Text，这会使更多页按钮使用文本而不是图片按钮。</remarks>
        [Browsable(true),
            Category("导航按钮"),
            DefaultValue(PagingButtonType.Text),
            Description("“更多页”（...）按钮的类型")]
        public PagingButtonType MoreButtonType
        {
            get
            {
                object obj = ViewState["MoreButtonType"];
                return (obj == null) ? PagingButtonType : (PagingButtonType)obj;
            }
            set
            {
                ViewState["MoreButtonType"] = value;
            }
        }

        /// <summary>
        /// 获取或设置分页导航按钮之间的间距。
        /// </summary>
        /// <value>The paging button spacing.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("导航按钮"),
            DefaultValue(typeof(Unit), "5px"),
            Description("分页导航按钮之间的间距")]
        public Unit PagingButtonSpacing
        {
            get
            {
                object obj = ViewState["PagingButtonSpacing"];
                return (obj == null) ? Unit.Pixel(5) : (Unit.Parse(obj.ToString()));
            }
            set
            {
                ViewState["PagingButtonSpacing"] = value;
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否在页导航元素中显示第一页和最后一页按钮。
        /// </summary>
        /// <value><c>true</c> if [show first last]; otherwise, <c>false</c>.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Description("是否在页导航元素中显示第一页和最后一页按钮"),
            Category("导航按钮"),
            DefaultValue(true)]
        public bool ShowFirstLast
        {
            get
            {
                object obj = ViewState["ShowFirstLast"];
                return (obj == null) ? true : (bool)obj;
            }
            set { ViewState["ShowFirstLast"] = value; }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否在页导航元素中显示上一页和下一页按钮。
        /// </summary>
        /// <value><c>true</c> if [show prev next]; otherwise, <c>false</c>.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Description("是否在页导航元素中显示上一页和下一页按钮"),
            Category("导航按钮"),
            DefaultValue(true)]
        public bool ShowPrevNext
        {
            get
            {
                object obj = ViewState["ShowPrevNext"];
                return (obj == null) ? true : (bool)obj;
            }
            set { ViewState["ShowPrevNext"] = value; }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否在页导航元素中显示页索引数值按钮。
        /// </summary>
        /// <value><c>true</c> if [show page index]; otherwise, <c>false</c>.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Description("是否在页导航元素中显示数值按钮"),
            Category("导航按钮"),
            DefaultValue(false)]
        public bool ShowPageIndex
        {
            get
            {
                object obj = ViewState["ShowPageIndex"];
                return (obj == null) ? false : (bool)obj;
            }
            set { ViewState["ShowPageIndex"] = value; }
        }

        /// <summary>
        /// 获取或设置为第一页按钮显示的文本。
        /// </summary>
        /// <value>The first page text.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Description("第一页按钮上显示的文本"),
            Category("导航按钮"),
            DefaultValue("首页")]
        public string FirstPageText
        {
            get
            {
                object obj = ViewState["FirstPageText"];
                return (obj == null) ? "首页" : (string)obj;
            }
            set { ViewState["FirstPageText"] = value; }
        }

        /// <summary>
        /// 获取或设置为上一页按钮显示的文本。
        /// </summary>
        /// <value>The prev page text.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Description("上一页按钮上显示的文本"),
            Category("导航按钮"),
            DefaultValue("上一页")]
        public string PrevPageText
        {
            get
            {
                object obj = ViewState["PrevPageText"];
                return (obj == null) ? "上一页" : (string)obj;
            }
            set { ViewState["PrevPageText"] = value; }
        }

        /// <summary>
        /// 获取或设置为下一页按钮显示的文本。
        /// </summary>
        /// <value>The next page text.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Description("下一页按钮上显示的文本"),
            Category("导航按钮"),
            DefaultValue("下一页")]
        public string NextPageText
        {
            get
            {
                object obj = ViewState["NextPageText"];
                return (obj == null) ? "下一页" : (string)obj;
            }
            set { ViewState["NextPageText"] = value; }
        }

        /// <summary>
        /// 获取或设置为最后一页按钮显示的文本。
        /// </summary>
        /// <value>The last page text.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Description("最后一页按钮上显示的文本"),
            Category("导航按钮"),
            DefaultValue("末页")]
        public string LastPageText
        {
            get
            {
                object obj = ViewState["LastPageText"];
                return (obj == null) ? "末页" : (string)obj;
            }
            set { ViewState["LastPageText"] = value; }
        }

        /// <summary>
        /// 获取或设置在 <see cref="Net2Pager" /> 控件的页导航元素中同时显示的数值按钮的数目。
        /// </summary>
        /// <value>The numeric button count.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Description("要显示的页索引数值按钮的数目"),
            Category("导航按钮"),
            DefaultValue(10)]
        public int NumericButtonCount
        {
            get
            {
                object obj = ViewState["NumericButtonCount"];
                return (obj == null) ? 10 : (int)obj;
            }
            set { ViewState["NumericButtonCount"] = value; }
        }

        /// <summary>
        /// 获取或设置一个值，该值指定是否显示已禁用的按钮。
        /// </summary>
        /// <value><c>true</c> if [show disabled buttons]; otherwise, <c>false</c>.</value>
        /// <remarks>该值用来指定是否显示已禁用的分页导航按钮，当当前页为第一页时，第一页和上一页按钮将被禁用，当当前页为最后一页时，下一页和最后一页按钮将被禁用，被禁用的按钮没有链接，在按钮上点击也不会有任何作用。</remarks>
        [Browsable(true),
            Category("导航按钮"),
            Description("是否显示已禁用的按钮"),
            DefaultValue(true)]
        public bool ShowDisabledButtons
        {
            get
            {
                object obj = ViewState["ShowDisabledButtons"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                ViewState["ShowDisabledButtons"] = value;
            }
        }

        #endregion

        #region Image Buttons

        /// <summary>
        /// 获取或设置当使用图片按钮时，图片文件的路径。
        /// </summary>
        /// <value>The image path.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("图片按钮"),
            Description("当使用图片按钮时，指定图片文件的路径"),
            DefaultValue(null)]
        public string ImagePath
        {
            get
            {
                string imgPath = (string)ViewState["ImagePath"];
                if (imgPath != null)
                    imgPath = this.ResolveUrl(imgPath);
                return imgPath;
            }
            set
            {
                string imgPath = value.Trim().Replace("\\", "/");
                ViewState["ImagePath"] = (imgPath.EndsWith("/")) ? imgPath : imgPath + "/";
            }
        }

        /// <summary>
        /// 获取或设置当使用图片按钮时，图片的类型，如gif或jpg，该值即图片文件的后缀名。
        /// </summary>
        /// <value>The button image extension.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("图片按钮"),
            DefaultValue(".gif"),
            Description("当使用图片按钮时，图片的类型，如gif或jpg，该值即图片文件的后缀名")]
        public string ButtonImageExtension
        {
            get
            {
                object obj = ViewState["ButtonImageExtension"];
                return (obj == null) ? ".gif" : (string)obj;
            }
            set
            {
                string ext = value.Trim();
                ViewState["ButtonImageExtension"] = (ext.StartsWith(".")) ? ext : ("." + ext);
            }
        }

        /// <summary>
        /// 获取或设置自定义图片文件名的后缀字符串，以区分不同类型的按钮图片。
        /// </summary>
        /// <value>The button image name extension.</value>
        /// <remarks><note>注意：</note>该值不是文件后缀名，而是为区分不同的图片文件而在图片名中加入的字符串，如：
        /// 当前有两套按钮图片，其中一套中的“1”的图片名可为“1f.gif”，另一套中的“1”的图片名可起为“1n.gif”，其中的f和n即为ButtonImageNameExtension。</remarks>
        [Browsable(true),
            DefaultValue(null),
            Category("图片按钮"),
            Description("自定义图片文件名的后缀字符串（非文件后缀名），如图片“1f.gif”的ButtonImageNameExtension即为“f”")]
        public string ButtonImageNameExtension
        {
            get
            {
                return (string)ViewState["ButtonImageNameExtension"];
            }
            set
            {
                ViewState["ButtonImageNameExtension"] = value;
            }
        }

        /// <summary>
        /// 获取或设置当前页索引按钮的图片名后缀。
        /// </summary>
        /// <value>The cpi button image name extension.</value>
        /// <remarks>当 <see cref="PagingButtonType" /> 设为 Image 时，该属性允许您设置当前页索引数值按钮使用的图片名后缀字符，因此可以使当前页索引按钮与其它页索引按钮使用不同的图片，若未设置该值，则默认值为<see cref="ButtonImageNameExtension" />，即当前页索引按钮与其它页索引按钮使用相同的图片。</remarks>
        [Browsable(true),
            DefaultValue(null),
            Category("图片按钮"),
            Description("当前页索引按钮的图片名后缀字符串")]
        public string CpiButtonImageNameExtension
        {
            get
            {
                object obj = ViewState["CpiButtonImageNameExtension"];
                return (obj == null) ? ButtonImageNameExtension : (string)obj;
            }
            set
            {
                ViewState["CpiButtonImageNameExtension"] = value;
            }
        }

        /// <summary>
        /// 获取或设置已禁用的页导航按钮图片名后缀字符串。
        /// </summary>
        /// <value>The disabled button image name extension.</value>
        /// <remarks>当 <see cref="PagingButtonType" /> 设为 Image 时， 该值允许您设置已禁用（即没有链接，因而点击后无反应）的页导航按钮（包括第一页、上一页、下一页、最后一页四个按钮）的图片文件名后缀字符串，因此可以使已禁用的页导航按钮不同于正常的页导航按钮。若未设置该值，则默认值为<see cref="ButtonImageNameExtension" />，即已禁用的页导航按钮与正常的页导航按钮使用相同的图片。</remarks>
        [Browsable(true),
            DefaultValue(null),
            Category("图片按钮"),
            Description("已禁用的页导航按钮的图片名后缀字符串")]
        public string DisabledButtonImageNameExtension
        {
            get
            {
                object obj = ViewState["DisabledButtonImageNameExtension"];
                return (obj == null) ? ButtonImageNameExtension : (string)obj;
            }
            set
            {
                ViewState["DisabledButtonImageNameExtension"] = value;
            }
        }
        /// <summary>
        /// 指定当使用图片按钮时，图片的对齐方式。
        /// </summary>
        /// <value>The button image align.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Description("指定当使用图片按钮时，图片的对齐方式"),
            DefaultValue(ImageAlign.Baseline),
            Category("图片按钮")]
        public ImageAlign ButtonImageAlign
        {
            get
            {
                object obj = ViewState["ButtonImageAlign"];
                return (obj == null) ? ImageAlign.Baseline : (ImageAlign)obj;
            }
            set { ViewState["ButtonImageAlign"] = value; }
        }


        #endregion

        #region Paging

        /// <summary>
        /// 获取或设置当前显示页的索引。
        /// </summary>
        /// <value>The index of the current page.</value>
        /// <remarks>使用此属性来确定在 Net2Pager 控件中当前显示的页，当前显示的页的数字索引将以红色字体加粗显示。此属性还用于以编程的方式控制所显示的页。
        /// <p>　<b>注意：</b>不同于GridView控件的CurrentPageIndex，Net2Pager的CurrentPageIndex属性是从1开始的。</p></remarks>
        [ReadOnly(true),
            Browsable(false),
            Description("当前显示页的索引"),
            Category("分页"),
            DefaultValue(1),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentPageIndex
        {
            get
            {
                object cpage = ViewState["CurrentPageIndex"];
                int pindex = (cpage == null) ? 1 : (int)cpage;
                if (pindex > PageCount && PageCount > 0)
                    return PageCount;
                else if (pindex < 1)
                    return 1;
                return pindex;
            }
            set
            {
                int cpage = value;
                if (cpage < 1)
                    cpage = 1;
                else if (cpage > this.PageCount)
                    cpage = this.PageCount;
                ViewState["CurrentPageIndex"] = cpage;
            }
        }

        /// <summary>
        /// 获取或设置需要分页的所有记录的总数。
        /// </summary>
        /// <value>The record count.</value>
        /// <example>
        /// 下面的示例显示如何以编程方式将从Sql语句返回的记录总数赋给该属性：
        ///   <p>
        ///   <code><![CDATA[
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
        /// cmd=new SqlCommand("select count(id) from news",conn);
        /// conn.Open();
        /// pager.RecordCount=(int)cmd.ExecuteScalar();
        /// conn.Close();
        /// BindData();
        /// }
        /// }
        /// void BindData()
        /// {
        /// cmd=new SqlCommand("GetPagedNews",conn);
        /// cmd.CommandType=CommandType.StoredProcedure;
        /// cmd.Parameters.Add("@pageindex",pager.CurrentPageIndex);
        /// cmd.Parameters.Add("@pagesize",pager.PageSize);
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
        ///   <asp:GridView id="dataGrid1" runat="server" />
        ///   <Net2Pager:Net2Pager id="pager" runat="server"
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
        ///   </code></p>
        ///   <p>本示例使用的存储过程代码如下：</p>
        ///   <code><![CDATA[
        /// CREATE procedure GetPagedNews
        /// (@pagesize int,
        /// @pageindex int)
        /// as
        /// set nocount on
        /// declare @indextable table(id int identity(1,1),nid int)
        /// declare @PageLowerBound int
        /// declare @PageUpperBound int
        /// set @PageLowerBound=(@pageindex-1)*@pagesize
        /// set @PageUpperBound=@PageLowerBound+@pagesize
        /// set rowcount @PageUpperBound
        /// insert into @indextable(nid) select id from news order by addtime desc
        /// select O.id,O.title,O.source,O.addtime from news O,@indextable t where O.id=t.nid
        /// and t.id>@PageLowerBound and t.id<=@PageUpperBound order by t.id
        /// set nocount off
        /// GO
        /// ]]>
        ///   </code>
        ///   </example>
        /// <remarks>当页面第一次加载时，应以编程方式将从存储过程或Sql语句中返回的数据表中所有要分页的记录的总数赋予该属性，Net2Pager会将其保存的ViewState中并在页面回发时从ViewState中获取该值，因此避免了每次分页都要访问数据库而影响分页性能。Net2Pager根据要分页的所有数据的总项数和 <see cref="PageSize" /> 属性来计算显示所有数据需要的总页数，即 <see cref="PageCount" />的值。</remarks>
        [Browsable(false),
            Description("要分页的所有记录的总数，该值须在程序运行时设置，默认值为225是为设计时支持而设置的参照值。"),
            Category("Data"),
            DefaultValue(225)]
        public int RecordCount
        {
            get
            {
                object obj = ViewState["Recordcount"];
                return (obj == null) ? 0 : (int)obj;
            }
            set { ViewState["Recordcount"] = value; }
        }

        /// <summary>
        /// 获取当前页之后未显示的页的总数。
        /// </summary>
        /// <value>The pages remain.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PagesRemain
        {
            get
            {
                return PageCount - CurrentPageIndex;
            }
        }

        /// <summary>
        /// 获取或设置每页显示的项数。
        /// </summary>
        /// <value>The size of the page.</value>
        /// <example>以下示例将 <see cref="Net2Pager" /> 设置为允许每页显示8条数据：
        ///   <code>
        ///   <![CDATA[
        /// ...
        ///   <Net2Pager:Net2Pager id="pager" runat="server" PageSize=8 OnPageChanged="ChangePage"/>
        /// ...
        /// ]]></code></example>
        /// <remarks>该值获取或设置数据呈现控件每次要显示数据表中的的数据的项数，Net2Pager根据该值和 <see cref="RecordCount" /> 来计算显示所有数据需要的总页数，即 <see cref="PageCount" />的值。</remarks>
        [Browsable(true),
            Description("每页显示的记录数"),
            Category("分页"),
            DefaultValue(10)]
        public int PageSize
        {
            get
            {
                object obj = ViewState["PageSize"];
                return (obj == null) ? 10 : (int)obj;
            }
            set
            {
                ViewState["PageSize"] = value;
            }
        }

        /// <summary>
        /// 获取在当前页之后还未显示的剩余记录的项数。
        /// </summary>
        /// <value>The records remain.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RecordsRemain
        {
            get
            {
                if (CurrentPageIndex < PageCount)
                    return RecordCount - (CurrentPageIndex * PageSize);
                return 0;
            }
        }


        /// <summary>
        /// 获取所有要分页的记录需要的总页数。
        /// </summary>
        /// <value>The page count.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PageCount
        {
            get { return (int)Math.Ceiling((double)RecordCount / (double)PageSize); }
        }


        #endregion

        #region TextBox and Submit Button

        /// <summary>
        /// 获取或设置页索引文本框的显示方式。
        /// </summary>
        /// <value>The show input box.</value>
        /// <remarks>页索引文件框允许用户手式输入要访问的页的索引，当页数非常多时，显示页索引文本框非常方便用户跳转到指定的页，默认情况下，该文本框只有在总页数大于或等于 <see cref="ShowBoxThreshold" /> 的值时才显示，否则不显示，要想该文本框任何时候都显示，请将其值设为Always，若希望任何时候都不显示，则应设为Never。</remarks>
        [Browsable(true),
            Description("指定页索引文本框的显示方式"),
            Category("文本框及提交按钮"),
            DefaultValue(ShowInputBox.Auto)]
        public ShowInputBox ShowInputBox
        {
            get
            {
                object obj = ViewState["ShowInputBox"];
                return (obj == null) ? ShowInputBox.Auto : (ShowInputBox)obj;
            }
            set { ViewState["ShowInputBox"] = value; }
        }

        /// <summary>
        /// 获取或设置应用于页索引输入文本框的CSS类名。
        /// </summary>
        /// <value>The input box class.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("文本框及提交按钮"),
            DefaultValue(null),
            Description("应用于页索引输入文本框的CSS类名")]
        public string InputBoxClass
        {
            get
            {
                return (string)ViewState["InputBoxClass"];
            }
            set
            {
                if (value.Trim().Length > 0)
                    ViewState["InputBoxClass"] = value;
            }
        }

        /// <summary>
        /// 获取或设置页索引输入文本框的CSS样式文本。
        /// </summary>
        /// <value>The input box style.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("文本框及提交按钮"),
            DefaultValue(null),
            Description("应用于页索引输入文本框的CSS样式文本")]
        public string InputBoxStyle
        {
            get
            {
                return (string)ViewState["InputBoxStyle"];
            }
            set
            {
                if (value.Trim().Length > 0)
                    ViewState["InputBoxStyle"] = value;
            }
        }

        /// <summary>
        /// 获取或设置页索引页索引输入文本框前的文本字符串值。
        /// </summary>
        /// <value>The text before input box.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("文本框及提交按钮"),
            DefaultValue(null),
            Description("页索引输入文本框前的文本内容字符串")]
        public string TextBeforeInputBox
        {
            get
            {
                return (string)ViewState["TextBeforeInputBox"];
            }
            set
            {
                ViewState["TextBeforeInputBox"] = value;
            }
        }

        /// <summary>
        /// 获取或设置页索引文本输入框后的文本内容字符串值。
        /// </summary>
        /// <value>The text after input box.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            DefaultValue(null),
            Category("文本框及提交按钮"),
            Description("页索引输入文本框后的文本内容字符串")]
        public string TextAfterInputBox
        {
            get
            {
                return (string)ViewState["TextAfterInputBox"];
            }
            set
            {
                ViewState["TextAfterInputBox"] = value;
            }
        }


        /// <summary>
        /// 获取或设置提交按钮上的文本。
        /// </summary>
        /// <value>The submit button text.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("文本框及提交按钮"),
            DefaultValue("转到"),
            Description("提交按钮上的文本")]
        public string SubmitButtonText
        {
            get
            {
                object obj = ViewState["SubmitButtonText"];
                return (obj == null) ? "转到" : (string)obj;
            }
            set
            {
                if (value.Trim().Length > 0)
                    ViewState["SubmitButtonText"] = value;
            }
        }
        /// <summary>
        /// 获取或设置应用于提交按钮的CSS类名。
        /// </summary>
        /// <value>The submit button class.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("文本框及提交按钮"),
            DefaultValue(null),
            Description("应用于提交按钮的CSS类名")]
        public string SubmitButtonClass
        {
            get
            {
                return (string)ViewState["SubmitButtonClass"];
            }
            set
            {
                ViewState["SubmitButtonClass"] = value;
            }
        }

        /// <summary>
        /// 获取或设置应用于提交按钮的CSS样式。
        /// </summary>
        /// <value>The submit button style.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("文本框及提交按钮"),
            DefaultValue(null),
            Description("应用于提交按钮的CSS样式")]
        public string SubmitButtonStyle
        {
            get
            {
                return (string)ViewState["SubmitButtonStyle"];
            }
            set
            {
                ViewState["SubmitButtonStyle"] = value;
            }
        }
        /// <summary>
        /// 获取或设置自动显示页索引输入文本框的最低起始页数。
        /// </summary>
        /// <value>The show box threshold.</value>
        /// <remarks>当 <see cref="ShowInputBox" /> 设为Auto（默认）并且要分页的数据的总页数达到该值时会自动显示页索引输入文本框，默认值为30。该选项当 <see cref="ShowInputBox" /> 设为Never或Always时没有任何作用。</remarks>
        [Browsable(true),
            Description("指定当ShowInputBox设为ShowInputBox.Auto时，当总页数达到多少时才显示页索引输入文本框"),
            Category("文本框及提交按钮"),
            DefaultValue(30)]
        public int ShowBoxThreshold
        {
            get
            {
                object obj = ViewState["ShowBoxThreshold"];
                return (obj == null) ? 30 : (int)obj;
            }
            set { ViewState["ShowBoxThreshold"] = value; }
        }


        #endregion

        #region CustomInfoSection

        /// <summary>
        /// 获取或设置显示用户自定义信息区的方式。
        /// </summary>
        /// <value>The show custom info section.</value>
        /// <remarks>该属性值设为Left或Right时会在分页导航元素左边或右边划出一个专门的区域来显示有关用户自定义信息，设为Never时不显示。</remarks>
        [Browsable(true),
            Description("显示当前页和总页数信息，默认值为不显示，值为ShowCustomInfoSection.Left时将显示在页索引前，为ShowCustomInfoSection.Right时将显示在页索引后"),
            DefaultValue(ShowCustomInfoSection.Never),
            Category("自定义信息区")]
        public ShowCustomInfoSection ShowCustomInfoSection
        {
            get
            {
                object obj = ViewState["ShowCustomInfoSection"];
                return (obj == null) ? ShowCustomInfoSection.Never : (ShowCustomInfoSection)obj;
            }
            set { ViewState["ShowCustomInfoSection"] = value; }
        }

        /// <summary>
        /// 获取或设置用户自定义信息区文本的对齐方式。
        /// </summary>
        /// <value>The custom info text align.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("自定义信息区"),
            DefaultValue(HorizontalAlign.Left),
            Description("用户自定义信息区文本的对齐方式")]
        public HorizontalAlign CustomInfoTextAlign
        {
            get
            {
                object obj = ViewState["CustomInfoTextAlign"];
                return (obj == null) ? HorizontalAlign.Left : (HorizontalAlign)obj;
            }
            set
            {
                ViewState["CustomInfoTextAlign"] = value;
            }
        }

        /// <summary>
        /// 获取或设置用户自定义信息区的宽度。
        /// </summary>
        /// <value>The width of the custom info section.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("自定义信息区"),
            DefaultValue(typeof(Unit), "40%"),
            Description("用户自定义信息区的宽度")]
        public Unit CustomInfoSectionWidth
        {
            get
            {
                object obj = ViewState["CustomInfoSectionWidth"];
                return (obj == null) ? Unit.Percentage(40) : (Unit)obj;
            }
            set
            {
                ViewState["CustomInfoSectionWidth"] = value;
            }
        }

        /// <summary>
        /// 获取或设置应用于用户自定义信息区的级联样式表类名。
        /// </summary>
        /// <value>The custom info class.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("自定义信息区"),
            DefaultValue(null),
            Description("应用于用户自定义信息区的级联样式表类名")]
        public string CustomInfoClass
        {
            get
            {
                object obj = ViewState["CustomInfoClass"];
                return (obj == null) ? CssClass : (string)obj;
            }
            set
            {
                ViewState["CustomInfoClass"] = value;
            }
        }

        /// <summary>
        /// 获取或设置应用于用户自定义信息区的CSS样式文本。
        /// </summary>
        /// <value>字符串值，要应用于用户自定义信息区的CSS样式文本。</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("自定义信息区"),
            DefaultValue(null),
            Description("应用于用户自定义信息区的CSS样式文本")]
        public string CustomInfoStyle
        {
            get
            {
                object obj = ViewState["CustomInfoStyle"];
                return (obj == null) ? GetStyleString() : (string)obj;
            }
            set
            {
                ViewState["CustomInfoStyle"] = value;
            }
        }

        /// <summary>
        /// 获取或设置在显示在用户自定义信息区的用户自定义文本。
        /// </summary>
        /// <value>The custom info text.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Category("自定义信息区"),
            DefaultValue(null),
            Description("要显示在用户自定义信息区的用户自定义信息文本")]
        public string CustomInfoText
        {
            get
            {
                return (string)ViewState["CustomInfoText"];
            }
            set
            {
                ViewState["CustomInfoText"] = value;
            }
        }

        #endregion

        #region Others

        /// <summary>
        /// 获取或设置一个值，该值指定是否总是显示Net2Pager分页按件，即使要分页的数据只有一页。
        /// </summary>
        /// <value><c>true</c> if [always show]; otherwise, <c>false</c>.</value>
        /// <remarks>默认情况下，当要分页的数据小于两页时，Net2Pager不会在页面上显示任何内容，将此属性值设为true时，即使总页数只有一页，Net2Pager也将显示分页导航元素。</remarks>
        [Browsable(true),
            Category("Behavior"),
            DefaultValue(false),
            Description("总是显示分页控件，即使要分页的数据只要一页")]
        public bool AlwaysShow
        {
            get
            {
                object obj = ViewState["AlwaysShow"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                ViewState["AlwaysShow"] = value;
            }
        }


        /// <summary>
        /// 获取或设置由 Net2Pager 服务器控件在客户端呈现的级联样式表 (CSS) 类。
        /// </summary>
        /// <value>The CSS class.</value>
        /// <returns>The CSS class rendered by the Web server control on the client. The default is <see cref="F:System.String.Empty" />.</returns>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Description("应用于控件的CSS类名"),
            Category("Appearance"),
            DefaultValue(null)]
        public override string CssClass
        {
            get { return base.CssClass; }
            set
            {
                base.CssClass = value;
                cssClassName = value;
            }
        }


        /// <summary>
        /// 获取或设置一个值，该值指示 Net2Pager 服务器控件是否向发出请求的客户端保持自己的视图状态，该属性经重写后不允许设为false。
        /// </summary>
        /// <value><c>true</c> if [enable view state]; otherwise, <c>false</c>.</value>
        /// <returns>true if the server control maintains its view state; otherwise false. The default is true.</returns>
        /// <remarks><see cref="Net2Pager" /> 服务器控件将一些重要的分页信息保存在ViewState中，当使用Url分页方式时，虽然视图状态在分页过程中没有任何作用，但若当前页需要回发，则必须启用视图状态以便分页控件能在页面回发后获取回发前的分页状态；当通过页面回发（PostBack）的方式来分页时，要使Net2Pager正常工作，必须启用视图状态。
        ///   <p><note>该属性并不能禁止用户用<![CDATA[<%@Page EnableViewState=false%> ]]>页指令来禁用整个页面的视图状态，当使用此指令并且设置Net2Pager通过页面回发来分页时，Net2Pager因为无法获取保存的信息而不能正常工作。</note></p></remarks>
        [Browsable(false),
            Description("是否启用控件的视图状态，该属性的值必须为true，不允许用户设置。"),
            DefaultValue(true),
            Category("Behavior")]
        public override bool EnableViewState
        {
            get
            {
                return base.EnableViewState;
            }
            set
            {
                base.EnableViewState = true;
            }
        }

        /// <summary>
        /// 获取或设置当用户输入的页索引超出范围（大于最大页索引或小于最小页索引）时在客户端显示的错误信息。
        /// </summary>
        /// <value>The page index out of range error string.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Description("当用户输入的页索引超出范围（大于最大页索引或小于最小页索引）时在客户端显示的错误信息。"),
            DefaultValue("页数超出范围！"),
            Category("Data")]
        public string PageIndexOutOfRangeErrorString
        {
            get
            {
                object obj = ViewState["PageIndexOutOfRangeErrorString"];
                return (obj == null) ? "页数超出范围！" : (string)obj;
            }
            set
            {
                ViewState["PageIndexOutOfRangeErrorString"] = value;
            }
        }

        /// <summary>
        /// 获取或设置当用户输入无效的页索引（负值或非数字）时在客户端显示的错误信息。
        /// </summary>
        /// <value>The invalid page index error string.</value>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        [Browsable(true),
            Description("当用户输入无效的页索引（负值或非数字）时在客户端显示的错误信息。"),
            DefaultValue("页索引无效！"),
            Category("Data")]
        public string InvalidPageIndexErrorString
        {
            get
            {
                object obj = ViewState["InvalidPageIndexErrorString"];
                return (obj == null) ? "页索引无效！" : (string)obj;
            }
            set
            {
                ViewState["InvalidPageIndexErrorString"] = value;
            }
        }




        #endregion

        #endregion

        #region Control Rendering Logic

        /// <summary>
        /// 重写 <see cref="System.Web.UI.Control.OnLoad" /> 方法。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="EventArgs" /> 对象。</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        protected override void OnLoad(EventArgs e)
        {
            inputPageIndex = Page.Request.Form[this.UniqueID + "_input"];
            base.OnLoad(e);
        }
        /// <summary>
        /// 重写<see cref="System.Web.UI.Control.OnPreRender" />方法。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="EventArgs" /> 对象。</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        protected override void OnPreRender(EventArgs e)
        {
            if (PageCount > 1)
            {
                string checkscript = "<script language=\"Javascript\">function doCheck(el){var r=new RegExp(\"^\\\\s*(\\\\d+)\\\\s*$\");if(r.test(el.value)){if(RegExp.$1<1||RegExp.$1>" + PageCount.ToString() + "){alert(\"" + PageIndexOutOfRangeErrorString + "\");document.all[\'" + this.UniqueID + "_input\'].select();return false;}return true;}alert(\"" + InvalidPageIndexErrorString + "\");document.all[\'" + this.UniqueID + "_input\'].select();return false;}</script>";

                ClientScriptManager manager1 = Page.ClientScript;
                Type type1 = base.GetType();

                if ((ShowInputBox == ShowInputBox.Always) || (ShowInputBox == ShowInputBox.Auto && PageCount >= ShowBoxThreshold))
                {
                    if (!manager1.IsClientScriptBlockRegistered("checkinput"))
                        manager1.RegisterClientScriptBlock(type1,"checkinput", checkscript);
  
                }
            }
            base.OnPreRender(e);
        }

        /// <summary>
        /// 重写<see cref="System.Web.UI.WebControls.WebControl.AddAttributesToRender" /> 方法，将需要呈现的 HTML 属性和样式添加到指定的 <see cref="System.Web.UI.HtmlTextWriter" /> 中
        /// </summary>
        /// <param name="writer">An <see cref="T:System.Web.UI.HtmlTextWriter" /> that represents the output stream to render HTML content on the client.</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            if (this.Page != null)
                this.Page.VerifyRenderingInServerForm(this);
            base.AddAttributesToRender(writer);
        }

        /// <summary>
        /// 重写 <see cref="System.Web.UI.WebControls.WebControl.RenderBeginTag" /> 方法，将 <see cref="Net2Pager" /> 控件的 HTML 开始标记输出到指定的 <see cref="System.Web.UI.HtmlTextWriter" /> 编写器中。
        /// </summary>
        /// <param name="writer"><see cref="System.Web.UI.HtmlTextWriter" />，表示要在客户端呈现 HTML 内容的输出流。</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            //重写RenderBeginTag 当显示自定义信息时的构建一个表格头
            bool showPager = (PageCount > 1 || (PageCount <= 1 && AlwaysShow));

            base.RenderBeginTag(writer);
            //			if(!showPager)
            //			{
            //				writer.Write("<!-----因为总页数只有一页，并且AlwaysShow属性设为false，Net2Pager不显示任何内容，若要在总页数只有一页的情况下显示Net2Pager，请将AlwaysShow属性设为true！");
            //				writer.Write("----->");
            //			}
            if ((ShowCustomInfoSection == ShowCustomInfoSection.Left || ShowCustomInfoSection == ShowCustomInfoSection.Right) && showPager)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Width, "100%");
                writer.AddAttribute(HtmlTextWriterAttribute.Style, GetStyleString());
                if (Height != Unit.Empty)
                    writer.AddStyleAttribute(HtmlTextWriterStyle.Height, Height.ToString());
                writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
                writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "0");
                writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
                writer.RenderBeginTag(HtmlTextWriterTag.Table);
                writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                WriteCellAttributes(writer, true);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
            }
        }

        /// <summary>
        /// 重写 <see cref="System.Web.UI.WebControls.WebControl.RenderEndTag" /> 方法，将 <see cref="Net2Pager" /> 控件的 HTML 结束标记输出到指定的 <see cref="System.Web.UI.HtmlTextWriter" /> 编写器中。
        /// </summary>
        /// <param name="writer"><see cref="System.Web.UI.HtmlTextWriter" />，表示要在客户端呈现 HTML 内容的输出流。</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            ////重写RenderEndTag 当显示自定义信息时的构建一个表格结尾
            if ((ShowCustomInfoSection == ShowCustomInfoSection.Left || ShowCustomInfoSection == ShowCustomInfoSection.Right) && (PageCount > 1 || (PageCount <= 1 && AlwaysShow)))
            {
                writer.RenderEndTag();
                writer.RenderEndTag();
                writer.RenderEndTag();
            }
            base.RenderEndTag(writer);

        }


        /// <summary>
        /// 重写 <see cref="System.Web.UI.WebControls.WebControl.RenderContents" /> 方法，将控件的内容呈现到指定 <see cref="System.Web.UI.HtmlTextWriter" /> 的编写器中。
        /// </summary>
        /// <param name="writer"><see cref="System.Web.UI.HtmlTextWriter" />，表示要在客户端呈现 HTML 内容的输出流。</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (PageCount <= 1 && !AlwaysShow)
                return;

            if (ShowCustomInfoSection == ShowCustomInfoSection.Left)
            {
                writer.Write(CustomInfoText);
                writer.RenderEndTag();
                WriteCellAttributes(writer, false);
                writer.AddAttribute(HtmlTextWriterAttribute.Class, CssClass);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
            }

            int midpage = ((CurrentPageIndex - 1) / NumericButtonCount);
            int pageoffset = midpage * NumericButtonCount;
            int endpage = ((pageoffset + NumericButtonCount) > PageCount) ? PageCount : (pageoffset + NumericButtonCount);
            this.CreateNavigationButton(writer, "first");
            this.CreateNavigationButton(writer, "prev");
            if (ShowPageIndex)
            {
                if (CurrentPageIndex > NumericButtonCount)
                    CreateMoreButton(writer, pageoffset);
                for (int i = pageoffset + 1; i <= endpage; i++)
                {
                    CreateNumericButton(writer, i);
                }
                if (PageCount > NumericButtonCount && endpage < PageCount)
                    CreateMoreButton(writer, endpage + 1);
            }
            this.CreateNavigationButton(writer, "next");
            this.CreateNavigationButton(writer, "last");
            if ((ShowInputBox == ShowInputBox.Always) || (ShowInputBox == ShowInputBox.Auto && PageCount >= ShowBoxThreshold))
            {
                writer.Write("&nbsp;&nbsp;&nbsp;&nbsp;");
                if (TextBeforeInputBox != null)
                    writer.Write(TextBeforeInputBox);
                writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
                writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "30px");
                writer.AddAttribute(HtmlTextWriterAttribute.Value, CurrentPageIndex.ToString());
                if (InputBoxStyle != null && InputBoxStyle.Trim().Length > 0)
                    writer.AddAttribute(HtmlTextWriterAttribute.Style, InputBoxStyle);
                if (InputBoxClass != null && InputBoxClass.Trim().Length > 0)
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, InputBoxClass);
                if (PageCount <= 1 && AlwaysShow)
                    writer.AddAttribute(HtmlTextWriterAttribute.ReadOnly, "true");
                writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID + "_input");
                string scriptRef = "doCheck(document.all[\'" + this.UniqueID + "_input\'])";
                string postRef = "if(event.keyCode==13){if(" + scriptRef + ")__doPostBack(\'" + this.UniqueID + "\',document.all[\'" + this.UniqueID + "_input\'].value);else{event.returnValue=false;}}";
                string keydownScript = "if(event.keyCode==13){if(" + scriptRef + "){event.returnValue=false;document.all[\'" + this.UniqueID + "\'][1].click();}else{event.returnValue=false;}}";
                writer.AddAttribute("onkeydown", postRef);
                writer.RenderBeginTag(HtmlTextWriterTag.Input);
                writer.RenderEndTag();
                if (TextAfterInputBox != null)
                    writer.Write(TextAfterInputBox);
                writer.AddAttribute(HtmlTextWriterAttribute.Type, "Submit");
                writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
                writer.AddAttribute(HtmlTextWriterAttribute.Value, SubmitButtonText);
                if (SubmitButtonClass != null && SubmitButtonClass.Trim().Length > 0)
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, SubmitButtonClass);
                if (SubmitButtonStyle != null && SubmitButtonStyle.Trim().Length > 0)
                    writer.AddAttribute(HtmlTextWriterAttribute.Style, SubmitButtonStyle);
                if (PageCount <= 1 && AlwaysShow)
                    writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "true");
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "return " + scriptRef);
                writer.RenderBeginTag(HtmlTextWriterTag.Input);
                writer.RenderEndTag();
            }

            if (ShowCustomInfoSection == ShowCustomInfoSection.Right)
            {
                writer.RenderEndTag();
                WriteCellAttributes(writer, false);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write(CustomInfoText);
            }
        }


        #endregion

        #region Private Helper Functions

        /// <summary>
        /// 将基控件的Style转换为CSS字符串。
        /// </summary>
        /// <returns>System.String.</returns>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private string GetStyleString()
        {
            if (Style.Count > 0)
            {
                string stl = null;
                string[] skeys = new string[Style.Count];
                Style.Keys.CopyTo(skeys, 0);
                for (int i = 0; i < skeys.Length; i++)
                {
                    stl += String.Concat(skeys[i], ":", Style[skeys[i]], ";");
                }
                return stl;
            }
            return null;
        }

        /// <summary>
        /// 为用户自定义信息区和页导航按钮区和td添加属性。
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="leftCell">是否为第一个td</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private void WriteCellAttributes(HtmlTextWriter writer, bool leftCell)
        {
            string customUnit = CustomInfoSectionWidth.ToString();
            if (ShowCustomInfoSection == ShowCustomInfoSection.Left && leftCell || ShowCustomInfoSection == ShowCustomInfoSection.Right && !leftCell)
            {
                if (CustomInfoClass != null && CustomInfoClass.Trim().Length > 0)
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, CustomInfoClass);
                if (CustomInfoStyle != null && CustomInfoStyle.Trim().Length > 0)
                    writer.AddAttribute(HtmlTextWriterAttribute.Style, CustomInfoStyle);
                writer.AddAttribute(HtmlTextWriterAttribute.Valign, "bottom");
                writer.AddStyleAttribute(HtmlTextWriterStyle.Width, customUnit);
                writer.AddAttribute(HtmlTextWriterAttribute.Align, CustomInfoTextAlign.ToString().ToLower());
            }
            else
            {
                if (CustomInfoSectionWidth.Type == UnitType.Percentage)
                {
                    customUnit = (Unit.Percentage(100 - CustomInfoSectionWidth.Value)).ToString();
                    writer.AddStyleAttribute(HtmlTextWriterStyle.Width, customUnit);
                }
                writer.AddAttribute(HtmlTextWriterAttribute.Valign, "bottom");
                writer.AddAttribute(HtmlTextWriterAttribute.Align, HorizontalAlign.ToString().ToLower());
            }
            writer.AddAttribute(HtmlTextWriterAttribute.Nowrap, "true");
        }

        /// <summary>
        /// 获取分页导航按钮的超链接字符串。
        /// </summary>
        /// <param name="pageIndex">该分页按钮相对应的页索引。</param>
        /// <returns>分页导航按钮的超链接字符串。</returns>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private string GetHrefString(int pageIndex)
        {
          // .net 1.1用法
          //  return Page.GetPostBackClientHyperlink(this, pageIndex.ToString());
            return Page.ClientScript.GetPostBackClientHyperlink(this, pageIndex.ToString());

        }

        /// <summary>
        /// 创建第一页、上一页、下一页及最后一页分页按钮。
        /// </summary>
        /// <param name="writer"><see cref="System.Web.UI.HtmlTextWriter" />，表示要在客户端呈现 HTML 内容的输出流。</param>
        /// <param name="btnname">分页按钮名。</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private void CreateNavigationButton(HtmlTextWriter writer, string btnname)
        {
            if (!ShowFirstLast && (btnname == "first" || btnname == "last"))
                return;
            if (!ShowPrevNext && (btnname == "prev" || btnname == "next"))
                return;
            string linktext = "";
            bool disabled;
            int pageIndex;
            bool imgButton = (PagingButtonType == PagingButtonType.Image && NavigationButtonType == PagingButtonType.Image);
            if (btnname == "prev" || btnname == "first")
            {
                disabled = (CurrentPageIndex <= 1);
                if (!ShowDisabledButtons && disabled)
                    return;
                pageIndex = (btnname == "first") ? 1 : (CurrentPageIndex - 1);
                if (imgButton)
                {
                    if (!disabled)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, GetHrefString(pageIndex));
                        AddToolTip(writer, pageIndex);
                        writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.AddAttribute(HtmlTextWriterAttribute.Src, String.Concat(ImagePath, btnname, ButtonImageNameExtension, ButtonImageExtension));
                        writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
                        writer.AddAttribute(HtmlTextWriterAttribute.Align, ButtonImageAlign.ToString());
                        writer.RenderBeginTag(HtmlTextWriterTag.Img);
                        writer.RenderEndTag();
                        writer.RenderEndTag();
                    }
                    else
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Src, String.Concat(ImagePath, btnname, DisabledButtonImageNameExtension, ButtonImageExtension));
                        writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
                        writer.AddAttribute(HtmlTextWriterAttribute.Align, ButtonImageAlign.ToString());
                        writer.RenderBeginTag(HtmlTextWriterTag.Img);
                        writer.RenderEndTag();
                    }
                }
                else
                {
                    linktext = (btnname == "prev") ? PrevPageText : FirstPageText;
                    if (disabled)
                        writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "true");
                    else
                    {
                        WriteCssClass(writer);
                        AddToolTip(writer, pageIndex);
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, GetHrefString(pageIndex));
                    }
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write(linktext);
                    writer.RenderEndTag();
                }
            }
            else
            {
                disabled = (CurrentPageIndex >= PageCount);
                if (!ShowDisabledButtons && disabled)
                    return;
                pageIndex = (btnname == "last") ? PageCount : (CurrentPageIndex + 1);
                if (imgButton)
                {
                    if (!disabled)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, GetHrefString(pageIndex));
                        AddToolTip(writer, pageIndex);
                        writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.AddAttribute(HtmlTextWriterAttribute.Src, String.Concat(ImagePath, btnname, ButtonImageNameExtension, ButtonImageExtension));
                        writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
                        writer.AddAttribute(HtmlTextWriterAttribute.Align, ButtonImageAlign.ToString());
                        writer.RenderBeginTag(HtmlTextWriterTag.Img);
                        writer.RenderEndTag();
                        writer.RenderEndTag();
                    }
                    else
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Src, String.Concat(ImagePath, btnname, DisabledButtonImageNameExtension, ButtonImageExtension));
                        writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
                        writer.AddAttribute(HtmlTextWriterAttribute.Align, ButtonImageAlign.ToString());
                        writer.RenderBeginTag(HtmlTextWriterTag.Img);
                        writer.RenderEndTag();
                    }
                }
                else
                {
                    linktext = (btnname == "next") ? NextPageText : LastPageText;
                    if (disabled)
                        writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "true");
                    else
                    {
                        WriteCssClass(writer);
                        AddToolTip(writer, pageIndex);
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, GetHrefString(pageIndex));
                    }
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write(linktext);
                    writer.RenderEndTag();
                }
            }
            WriteButtonSpace(writer);
        }

        /// <summary>
        /// 写入CSS类名。
        /// </summary>
        /// <param name="writer"><see cref="System.Web.UI.HtmlTextWriter" />，表示要在客户端呈现 HTML 内容的输出流。</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private void WriteCssClass(HtmlTextWriter writer)
        {
            if (cssClassName != null && cssClassName.Trim().Length > 0)
                writer.AddAttribute(HtmlTextWriterAttribute.Class, cssClassName);
        }

        /// <summary>
        /// 加入导航按钮提示文本。
        /// </summary>
        /// <param name="writer"><see cref="System.Web.UI.HtmlTextWriter" />，表示要在客户端呈现 HTML 内容的输出流。</param>
        /// <param name="pageIndex">导航按钮对应的页索引。</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private void AddToolTip(HtmlTextWriter writer, int pageIndex)
        {
            if (ShowNavigationToolTip)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Title, String.Format(NavigationToolTipTextFormatString, pageIndex));
            }
        }

        /// <summary>
        /// 创建分页数值导航按钮。
        /// </summary>
        /// <param name="writer"><see cref="System.Web.UI.HtmlTextWriter" />，表示要在客户端呈现 HTML 内容的输出流。</param>
        /// <param name="index">要创建按钮的页索引的值。</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private void CreateNumericButton(HtmlTextWriter writer, int index)
        {
            bool isCurrent = (index == CurrentPageIndex);
            if (PagingButtonType == PagingButtonType.Image && NumericButtonType == PagingButtonType.Image)
            {
                if (!isCurrent)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, GetHrefString(index));
                    AddToolTip(writer, index);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    CreateNumericImages(writer, index, isCurrent);
                    writer.RenderEndTag();
                }
                else
                    CreateNumericImages(writer, index, isCurrent);
            }
            else
            {
                if (isCurrent)
                {
                    writer.AddStyleAttribute(HtmlTextWriterStyle.FontWeight, "Bold");
                    writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "red");
                    writer.RenderBeginTag(HtmlTextWriterTag.Font);
                    if (NumericButtonTextFormatString.Length > 0)
                        writer.Write(String.Format(NumericButtonTextFormatString, index.ToString()));
                  //    writer.Write(String.Format(NumericButtonTextFormatString, (ChinesePageIndex == true) ? GetChinesePageIndex(index) : (index.ToString())));
                    else
                        writer.Write(index.ToString());
                 //     writer.Write((ChinesePageIndex == true) ? GetChinesePageIndex(index) : index.ToString());
                    writer.RenderEndTag();
                }
                else
                {
                    WriteCssClass(writer);
                    AddToolTip(writer, index);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, GetHrefString(index));
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    if (NumericButtonTextFormatString.Length > 0)
                        writer.Write(String.Format(NumericButtonTextFormatString, index.ToString()));
                      //  writer.Write(String.Format(NumericButtonTextFormatString, (ChinesePageIndex == true) ? GetChinesePageIndex(index) : (index.ToString())));
                    else
                        writer.Write(index.ToString());
                     //   writer.Write((ChinesePageIndex == true) ? GetChinesePageIndex(index) : index.ToString());
                    writer.RenderEndTag();
                }
            }
            WriteButtonSpace(writer);
        }

        /// <summary>
        /// 在分页导航元素间加入空格。
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private void WriteButtonSpace(HtmlTextWriter writer)
        {
            if (PagingButtonSpacing.Value > 0)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.Width, PagingButtonSpacing.ToString());
                writer.RenderBeginTag(HtmlTextWriterTag.Span);
                writer.RenderEndTag();
            }
        }

        #region 获取中文页索引字符。
        /// <summary>
        /// 获取中文页索引字符。
        /// </summary>
        /// <param name="index">中文字符对应的页索引数值</param>
        /// <returns>对应于页索引数值的中文字符</returns>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private string GetChinesePageIndex(int index)
        {
            Hashtable cnChars = new Hashtable();
            cnChars.Add("0", "Ｏ");
            cnChars.Add("1", "一");
            cnChars.Add("2", "二");
            cnChars.Add("3", "三");
            cnChars.Add("4", "四");
            cnChars.Add("5", "五");
            cnChars.Add("6", "六");
            cnChars.Add("7", "七");
            cnChars.Add("8", "八");
            cnChars.Add("9", "九");
            string indexStr = index.ToString();
            string retStr = "";
            for (int i = 0; i < indexStr.Length; i++)
            {
                retStr = String.Concat(retStr, cnChars[indexStr[i].ToString()]);
            }
            return retStr;
        }
        #endregion

        /// <summary>
        /// 创建页索引图片按钮。
        /// </summary>
        /// <param name="writer"><see cref="System.Web.UI.HtmlTextWriter" />，表示要在客户端呈现 HTML 内容的输出流。</param>
        /// <param name="index">页索引数值。</param>
        /// <param name="isCurrent">是否是当前页索引。</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private void CreateNumericImages(HtmlTextWriter writer, int index, bool isCurrent)
        {
            string indexStr = index.ToString();
            for (int i = 0; i < indexStr.Length; i++)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Src, String.Concat(ImagePath, indexStr[i], (isCurrent == true) ? CpiButtonImageNameExtension : ButtonImageNameExtension, ButtonImageExtension));
                writer.AddAttribute(HtmlTextWriterAttribute.Align, ButtonImageAlign.ToString());
                writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
                writer.RenderBeginTag(HtmlTextWriterTag.Img);
                writer.RenderEndTag();
            }
        }

        /// <summary>
        /// 创建“更多页”（...）按钮。
        /// </summary>
        /// <param name="writer"><see cref="System.Web.UI.HtmlTextWriter" />，表示要在客户端呈现 HTML 内容的输出流。</param>
        /// <param name="pageIndex">链接到按钮的页的索引。</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private void CreateMoreButton(HtmlTextWriter writer, int pageIndex)
        {
            WriteCssClass(writer);
            writer.AddAttribute(HtmlTextWriterAttribute.Href, GetHrefString(pageIndex));
            AddToolTip(writer, pageIndex);
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            if (PagingButtonType == PagingButtonType.Image && MoreButtonType == PagingButtonType.Image)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Src, String.Concat(ImagePath, "more", ButtonImageNameExtension, ButtonImageExtension));
                writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
                writer.AddAttribute(HtmlTextWriterAttribute.Align, ButtonImageAlign.ToString());
                writer.RenderBeginTag(HtmlTextWriterTag.Img);
                writer.RenderEndTag();
            }
            else
                writer.Write("...");
            writer.RenderEndTag();
            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, PagingButtonSpacing.ToString());
            writer.RenderBeginTag(HtmlTextWriterTag.Span);
            writer.RenderEndTag();
        }

        #endregion

        #region IPostBackEventHandler Implementation

        /// <summary>
        /// 实现<see cref="IPostBackEventHandler" /> 接口，使 <see cref="Net2Pager" /> 控件能够处理将窗体发送到服务器时引发的事件。
        /// </summary>
        /// <param name="args">The args.</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public void RaisePostBackEvent(string args)
        {
            int pageIndex = CurrentPageIndex;
            try
            {
                if (args == null || args == "")
                    args = inputPageIndex;
                pageIndex = int.Parse(args);
            }
            catch { }
            OnPageChanged(new PageChangedEventArgs(pageIndex));

        }


        #endregion

        #region IPostBackDataHandler Implementation

        /// <summary>
        /// 实现 <see cref="IPostBackDataHandler" /> 接口，为 <see cref="Net2Pager" /> 服务器控件处理回发数据。
        /// </summary>
        /// <param name="pkey">控件的主要标识符。</param>
        /// <param name="pcol">所有传入名称值的集合。</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public virtual bool LoadPostData(string pkey, NameValueCollection pcol)
        {
            string str = pcol[this.UniqueID + "_input"];
            if (str != null && str.Trim().Length > 0)
            {
                try
                {
                    int pindex = int.Parse(str);
                    if (pindex > 0 && pindex <= PageCount)
                    {
                        inputPageIndex = str;
                        Page.RegisterRequiresRaiseEvent(this);
                    }
                }
                catch
                { }
            }
            return false;
        }

        /// <summary>
        /// 实现 <see cref="IPostBackDataHandler" /> 接口，用信号要求服务器控件对象通知 ASP.NET 应用程序该控件的状态已更改。
        /// </summary>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public virtual void RaisePostDataChangedEvent() { }

        #endregion

        #region PageChanged Event
        /// <summary>
        /// 当页导航元素之一被单击或用户手工输入页索引提交时发生。
        /// </summary>
        /// <example>下面的示例显示如何为PageChanged事件指定和编写事件处理程序，在该事件处理程序中重新绑定GridView上显示的数据：
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
        ///   <asp:GridView id="dataGrid1" runat="server" />
        ///   <Net2Pager:Net2Pager id="pager" runat="server" PageSize="8" NumericButtonCount="8" ShowCustomInfoSection="before" ShowInputBox="always" CssClass="mypager" HorizontalAlign="center" OnPageChanged="ChangePage" />
        ///   </form>
        ///   </body>
        ///   </HTML>
        /// ]]>
        ///   </code>
        ///   <p>该示例所用的Sql Server存储过程代码如下：</p>
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
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public event PageChangedEventHandler PageChanged;

        #endregion

        #region OnPageChanged Method

        /// <summary>
        /// 引发 <see cref="PageChanged" /> 事件。这使您可以为事件提供自定义处理程序。
        /// </summary>
        /// <param name="e">一个 <see cref="PageChangedEventArgs" />，它包含事件数据。</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        protected virtual void OnPageChanged(PageChangedEventArgs e)
        {
            if (this.PageChanged != null)
                PageChanged(this, e);
        }

        #endregion
    }


    #endregion

    #region PageChangedEventHandler Delegate
    /// <summary>
    /// 表示处理 <see cref="Net2Pager.PageChanged" /> 事件的方法。
    /// </summary>
    /// <param name="src">The SRC.</param>
    /// <param name="e">The <see cref="PageChangedEventArgs"/> instance containing the event data.</param>
    /// <remarks>http://wintersun.cnblogs.com/</remarks>
    public delegate void PageChangedEventHandler(object src, PageChangedEventArgs e);

    #endregion

    

}