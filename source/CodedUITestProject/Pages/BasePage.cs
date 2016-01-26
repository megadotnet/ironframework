
namespace CodedUITestProject.Pages
{
    using Microsoft.VisualStudio.TestTools.UITesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
     
    public abstract class BasePage : UITestControl
    {
        protected const string BaseURL = "http://localhost:1960/";

        /// <summary>
        /// Gets URL address of the current page.
        /// </summary>
        public Uri PageUrl
        {
            get;
            protected set;
        }

        /// <summary>
        /// Store the root control for the page.
        /// </summary>
        protected UITestControl Body;

        /// <summary>
        /// Current broser window.
        /// </summary>
        protected BrowserWindow BrowserWindow { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BasePage()
        {
            this.ConstructUrl();
        }

        /// <summary>
        /// Navigate to the specyfic URL by using current browser window.
        /// </summary>
        /// <typeparam name="T">Type of the page.</typeparam>
        /// <returns>Created page object.</returns>
        public T NavigateTo<T>() where T : BasePage, new()
        {
            if (this.BrowserWindow == null)
            {
                throw new InvalidOperationException("BrowserWindow is null. Use Lunch to initialize browser.");
            }

            T page = new T();
            var url = page.ConstructUrl();

            this.BrowserWindow.NavigateToUrl(url);
            this.BrowserWindow.WaitForControlReady();

            page.Body = (this.BrowserWindow.CurrentDocumentWindow.GetChildren()[0] as UITestControl) as HtmlControl;

            return page;
        }

        /// <summary>
        /// Initialize page from current browser window.
        /// </summary>
        /// <typeparam name="T">Type of the page.</typeparam>
        /// <returns>Created page object.</returns>
        public T InitializePage<T>() where T : BasePage, new()
        {
            if (this.BrowserWindow == null)
            {
                throw new InvalidOperationException("BrowserWindow is null. Use Lunch to initialize browser.");
            }

            T page = new T();
            page.BrowserWindow = this.BrowserWindow;
            page.Body = (this.BrowserWindow.CurrentDocumentWindow.GetChildren()[0] as UITestControl) as HtmlControl;
            return page;
        }

        /// <summary>
        /// Builds derived page URL based on the BaseURL and specyfic page URL.
        /// </summary>
        /// <returns></returns>
        protected abstract Uri ConstructUrl();

        /// <summary>
        /// Veryfies derived page is displayed correctly.
        /// </summary>
        /// <returns></returns>
        public abstract bool IsValidPageDisplayed();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Type of the page to open.</typeparam>
        /// <param name="browser"></param>
        /// <param name="clearCookies"></param>
        /// <param name="maximized"></param>
        /// <returns>New page instance.</returns>
        /// <remarks>Requires to install http://visualstudiogallery.msdn.microsoft.com/11cfc881-f8c9-4f96-b303-a2780156628d .</remarks>
        public static T Launch<T>(
            Browser browser = Browser.IE,
            bool clearCookies = true,
            bool maximized = true)
            where T : BasePage, new()
        {
            T page = new T();

            var url = page.PageUrl;
            if (url == null)
            {
                throw new InvalidOperationException("Unable to find URL for requested page.");
            }

            var pathToBrowserExe = CodedUITestProject.BrowserFactory.GetBrowserExePath(browser);

            // Setting the currect frowser fot the test.
            BrowserWindow.CurrentBrowser = "ie";
            var window = BrowserWindow.Launch(page.ConstructUrl());
            page.BrowserWindow = window;

            if (window == null)
            {
                var errorMessage = string.Format("Unable to run browser under the path: {0}", pathToBrowserExe);
                throw new InvalidOperationException(errorMessage);
            }

            page.Body = (window.CurrentDocumentWindow.GetChildren()[0] as UITestControl) as HtmlControl;

            if (clearCookies)
            {
                BrowserWindow.ClearCookies();
            }

            window.Maximized = maximized;

            if (!page.IsValidPageDisplayed())
            {
                throw new InvalidOperationException("Invalid page is displayed.");
            }

            return page;
        }
    }
}
