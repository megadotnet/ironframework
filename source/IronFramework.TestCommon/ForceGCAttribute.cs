 

using System;
using System.Reflection;

namespace IronFramework.TestCommon
{
    public class ForceGCAttribute : Xunit.BeforeAfterTestAttribute
    {
        public override void After(MethodInfo methodUnderTest)
        {
            GC.Collect(99);
            GC.Collect(99);
            GC.Collect(99);
        }
    }
}
