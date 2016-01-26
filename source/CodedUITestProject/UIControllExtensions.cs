using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace CodedUITestProject
{
    public static class UIControllExtensions
    {
        public static T FindById<T>(this UITestControl control, string controlId) where T : HtmlControl, new()
        {
            var allResult = FindAll<T>(control, new SearchSelector() { ID = controlId });
            T resultControl = default(T);

            if (allResult.Any())
            {
                resultControl = allResult[0];
            }

            return resultControl;
        }

        /// <summary>
        /// Search HTML control by class name.
        /// </summary>
        /// <typeparam name="T">Type of the element to find.</typeparam>
        /// <param name="control">Control to extend.</param>
        /// <param name="className">Class name fo find.</param>
        /// <param name="contains">Determines control contains only one class with given name or given class name is part of css classes for control.</param>
        /// <returns></returns>
        public static T FindFirstByCssClass<T>(this UITestControl control, string className, bool contains = true) where T : HtmlControl, new()
        {
            if (contains)
            {
                className = string.Format("*{0}", className);
            }

            var allResult = FindAll<T>(control, new SearchSelector() { Class = className });
            T resultControl = default(T);

            if (allResult.Any())
            {
                resultControl = allResult[0];
            }

            return resultControl;
        }

        /// <summary>
        /// Set focus to the HTML input control and type all characters from passed string one by one.
        /// </summary>
        /// <param name="inputControl">Input to type text on.</param>
        /// <param name="text">Text to be typed to the control.</param>
        /// <param name="append">Determines control will be cleaned before start typing.</param>
        public static void TypeText(this HtmlEdit inputControl, string text, bool append = false)
        {
            if (inputControl == null)
            {
                throw new ArgumentNullException("inputControl");
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException("text");
            }

            inputControl.SetFocus();

            Assert.IsTrue(!inputControl.ReadOnly && inputControl.Enabled, "Control is disabled or read-only.");

            if (!append)
            {
                inputControl.Text = string.Empty;
            }

            inputControl.Text = text;
        }

        private static ReadOnlyCollection<T> FindAll<T>(this UITestControl control, SearchSelector selectorDefinition) where T : HtmlControl, new()
        {
            var result = new List<T>();
            T selectorElement = new T { Container = control };
            selectorElement.SearchProperties.AddRange(selectorDefinition.ToPropertyCollection());

            if (!selectorElement.Exists)
            {
                Trace.WriteLine(string.Format("Html {0} element not exists for given selector {1}.", typeof(T).Name, selectorDefinition), "UI CodedTest");
                return result.AsReadOnly();
            }

            return selectorElement.FindMatchingControls().Select(c => (T)c).ToList().AsReadOnly();
        }
    }
}
