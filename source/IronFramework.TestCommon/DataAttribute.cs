 

using System;

namespace IronFramework.TestCommon
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class DataAttribute : Xunit.Extensions.DataAttribute
    {
    }
}
