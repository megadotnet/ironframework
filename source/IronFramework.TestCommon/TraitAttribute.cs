 

using System;

namespace IronFramework.TestCommon
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class TraitAttribute : Xunit.TraitAttribute
    {
        public TraitAttribute(string name, string value)
            : base(name, value)
        {
        }
    }
}
