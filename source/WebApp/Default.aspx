<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>
<%@ Import Namespace="IronFramework.Utility.UI" %>
<%@Register TagPrefix="Net2Pager" Namespace="DiyControl.Pager" Assembly="Net2Pager"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to Iron Framework 
    </h2>
        <asp:Repeater ID="rptEmployee" runat="server">
            <ItemTemplate>
                <li>ID 
                     <%#this.Eval2<ServicePoxry.AWServiceReference.Employee>(_ => _.EmployeeID)%></li>
                    <li>
                     <%#this.Eval2<ServicePoxry.AWServiceReference.Employee>(_ => _.LoginID + "  (" + _.Title + ")")%>
                    </li>
            </ItemTemplate>
        </asp:Repeater>
               <Net2Pager:Net2Pager id="pager" 
                        runat="server" 
                        PageSize="10" 
                        NumericButtonCount="8" 
                        ShowCustomInfoSection="left" 
                        PagingButtonSpacing="0"
                        ShowInputBox="always" 
                        CssClass="mypager" 
                        HorizontalAlign="right" 
                        OnPageChanged="ChangePage"  
                        SubmitButtonText="Go" 
                        NumericButtonTextFormatString="[{0}]" 
        FirstPageText="First" InvalidPageIndexErrorString="InvalidateIndex" 
        LastPageText="Last" NavigationToolTipTextFormatString="Jump {0}page" 
        NextPageText="Next" PageIndexOutOfRangeErrorString="Out of PageIndex!" 
        PrevPageText="Prev"/>

</asp:Content>
