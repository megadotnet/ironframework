

namespace CodedUITestProject.Pages
{
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a Login page.
    /// </summary>
    public class IndexPage : BasePage
    {
        /// <summary>
        /// The Id of the login textbox.
        /// </summary>
        private const string H1LabelId = "h1label";


        private const string Page = "Home/Index";

        /// <summary>
        /// Builds URL  for the page.
        /// </summary>
        /// <returns>The URL to specyfic page.</returns>
        protected override Uri ConstructUrl()
        {
            this.PageUrl = new Uri(string.Format("{0}{1}",BasePage.BaseURL,Page));
            return this.PageUrl;
        }

        /// <summary>
        /// Validate the correct page displayed.
        /// </summary>
        /// <returns></returns>
        public override bool IsValidPageDisplayed()
        {
            return this.Body.FindById<HtmlLabel>(H1LabelId) != null;
        }

        /// <summary>
        /// Gets a errr dialog window - when login failed.
        /// </summary>
        public HtmlControl ErrorDialog
        {
            get
            {
                return this.Body.FindFirstByCssClass<HtmlControl>("*");
            }
        }
    }
}
