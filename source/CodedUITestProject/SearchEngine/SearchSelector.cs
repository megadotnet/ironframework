using Microsoft.VisualStudio.TestTools.UITesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUITestProject
{
    public class SearchSelector
    {
        /// <summary>
        /// Id of the element.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// CSS class of the element.
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// HTML Tag name.
        /// </summary>
        public string TagName { get; set; }

        public PropertyExpressionCollection ToPropertyCollection()
        {
            var resultCollection = new PropertyExpressionCollection();
            var type = typeof(SearchSelector);

            var properties = type.GetProperties();

            var propertyValue = string.Empty;
            foreach (var property in properties)
            {
                propertyValue = property.GetValue(this) as string;
                if (!string.IsNullOrWhiteSpace(propertyValue))
                {
                    if (propertyValue.Contains('*'))
                    {
                        propertyValue = propertyValue.Replace("*", string.Empty);
                        resultCollection.Add(property.Name, propertyValue, PropertyExpressionOperator.Contains);
                    }
                    else
                    {
                        resultCollection.Add(property.Name, propertyValue, PropertyExpressionOperator.EqualTo);
                    }
                }
            }

            return resultCollection;
        }

        /// <summary>
        /// Returns a string with all selector filters.
        /// </summary>
        /// <returns>String with all filters description.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var criteria = this.ToPropertyCollection();

            foreach (var searchParameter in criteria)
            {
                stringBuilder.AppendFormat(
                    "Name:{0}    Value:{1}.{2}",
                    searchParameter.PropertyName,
                    searchParameter.PropertyValue,
                    System.Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}
