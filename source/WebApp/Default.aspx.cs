// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Default.aspx.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The _ default.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApp
{
    using System;
    using System.Web.UI;

    using DiyControl.Pager;

    using ServicePoxry.AWServiceReference;

    /// <summary>
    /// The _ default.
    /// </summary>
    public partial class _Default : Page
    {
        #region Constants and Fields

        /// <summary>
        /// The service client.
        /// </summary>
        private readonly EmployeeBoServiceClient serviceClient = new EmployeeBoServiceClient();

        #endregion

        #region Public Methods

        /// <summary>
        /// The change page.
        /// </summary>
        /// <param name="src">
        /// The src.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void ChangePage(object src, PageChangedEventArgs e)
        {
            this.pager.CurrentPageIndex = e.NewPageIndex;
            this.BindData();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int count = 0;
                var datalist = this.serviceClient.FindEmployeeByTitle(out count, null, 1, 10);

                this.pager.RecordCount = count;
                this.BindData();
            }
        }

        /// <summary>
        /// The bind data.
        /// </summary>
        private void BindData()
        {
            int count = 0;
            this.rptEmployee.DataSource = this.serviceClient.FindEmployeeByTitle(
                out count, null, this.pager.CurrentPageIndex, this.pager.PageSize);
            this.rptEmployee.DataBind();

            this.pager.CustomInfoText = "Total count：<font color=\"blue\"><b>" + this.pager.RecordCount + "</b></font>";
            this.pager.CustomInfoText += " Total Page：<font color=\"blue\"><b>" + this.pager.PageCount + "</b></font>";
            this.pager.CustomInfoText += " CurrentPageIndex：<font color=\"red\"><b>" + this.pager.CurrentPageIndex
                                         + "</b></font>";
        }

        #endregion
    }
}