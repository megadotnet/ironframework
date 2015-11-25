using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Service
{
    public class ServiceProxyTest
    {
        /// <summary>
        /// Tests the get employee with client credentials.
        /// </summary>
        [Fact]
        public void TestGetEmployeeWithClientCredentials()
        {
            var serviceClient = new ServicePoxry.AWServiceReference.EmployeeBoServiceClient();
            ///http://stackoverflow.com/questions/4256520/wcf-error-the-x-509-certificate-cn-localhost-chain-building-failed
            serviceClient.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
System.ServiceModel.Security.X509CertificateValidationMode.None;
            serviceClient.ClientCredentials.UserName.UserName = "test";
            serviceClient.ClientCredentials.UserName.Password = "test123";
            var entity=serviceClient.GetEmployee(1);
            Assert.NotNull(entity);
        }
    }
}
