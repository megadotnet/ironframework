using System;
using GRPCEmployeeService;
using Grpc.Core;
using System.Linq;
using Xunit;

namespace IronFramework.GrpcService.Tests
{

    /// <summary>
    /// GRPCClientTests
    /// </summary>
    public class GRPCClientTests
    {
        /// <summary>
        /// GetEmployeeListTests
        /// </summary>
        [Fact]
        public void GetEmployeeListTests()
        {

            Channel channel = new Channel("127.0.0.1:9007", ChannelCredentials.Insecure);

            var client = new gRPC.gRPCClient(channel);

            //Get one Employee entity 
            var responseEmployee = client.GetEmployeeList(new GetEmployeeListRequest { EmployeeID = 1 });

            Assert.NotNull(responseEmployee);
            Assert.NotNull(responseEmployee.Items);
            Assert.NotNull(responseEmployee.Items.FirstOrDefault());
            Assert.NotNull(responseEmployee.Items.FirstOrDefault().Title);

            channel.ShutdownAsync().Wait();

        }
    }
}
