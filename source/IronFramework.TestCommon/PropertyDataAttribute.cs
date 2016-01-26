 

using System;

namespace IronFramework.TestCommon
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class PropertyDataAttribute : Xunit.Extensions.PropertyDataAttribute
    {
        public PropertyDataAttribute(string propertyName)
            : base(propertyName)
        {
        }
    }
}
