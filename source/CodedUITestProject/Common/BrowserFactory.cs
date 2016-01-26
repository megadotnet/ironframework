using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUITestProject
{
    /// <summary>
    /// Class to manage browser to run tests against.
    /// </summary>
    public class BrowserFactory
    {
        /// <summary>
        /// Resolving a browser exe path based on the Setting.
        /// </summary>
        /// <param name="browser"><see cref="Broser"/> type.</param>
        /// <returns>Path to the exe for specific browser.</returns>
        public static string GetBrowserExePath(Browser browser)
        {
            var path = string.Empty;
            var settings = Properties.Settings.Default;

            switch (browser)
            {
                case Browser.IE:
                    path = settings.IeExePath;
                    break;
                case Browser.Chrome:
                    path = settings.ChromeExePath;
                    break;
                case Browser.Firefox:
                    path = settings.FirefoxExePath;
                    break;
                case Browser.Opera:
                    path = settings.OperaExePath;
                    break;
                default:
                    path = settings.IeExePath;
                    break;
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new InvalidOperationException(string.Format("Path to the browser exe for {0} can not be empty.", browser.ToString()));
            }

            return path;
        }
    }
}
