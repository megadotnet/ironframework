 

using System;

namespace IronFramework.TestCommon
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class InlineDataAttribute : Xunit.Extensions.InlineDataAttribute
    {
        public InlineDataAttribute(params object[] dataValues)
            : base(dataValues)
        {
        }
    }
}
