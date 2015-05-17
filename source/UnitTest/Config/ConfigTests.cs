using IronFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Config
{
    public class ConfigTests
    {
        [Fact]
        public void TestGetSecurityConfigConfigUserID()
        {
            string nodeValue = SecurityConfig.UserID;
            Assert.NotNull(nodeValue);
        }

        [Fact]
        public void TestGetServiceConfigConfigConfigURI()
        {
            string nodeValue = ServiceConfig.URI;
            Assert.NotNull(nodeValue);
        }
    }
}
