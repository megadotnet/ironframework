using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITest.Common.UIMap;
using System.Linq;
using CodedUITestProject.Pages;

namespace CodedUITestProject
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class MVCAppUITests
    {

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        /// <summary>
        /// Testing for invalid login.
        /// </summary>
        [TestMethod]
        public void ValidIndex()
        {
            var indexPage = BasePage.Launch<IndexPage>();
            Assert.IsTrue(indexPage.IsValidPageDisplayed(), "indexPage page is not displayed.");
        }


        [TestCleanup]
        public void TestCleanup()
        {
            if (this.TestContext.CurrentTestOutcome != null && this.TestContext.CurrentTestOutcome.ToString() == "Failed")
            {
                try
                {
                    var img = BrowserWindow.Desktop.CaptureImage();
                    var pathToSave = System.IO.Path.Combine(this.TestContext.TestResultsDirectory, string.Format("{0}.jpg", this.TestContext.TestName));
                    var bitmap = new Bitmap(img);
                    bitmap.Save(pathToSave);
                }
                catch
                {
                    this.TestContext.WriteLine("Unable to capture or save screen.");
                }
            }
        }
    }
}