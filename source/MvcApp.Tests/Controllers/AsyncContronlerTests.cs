using MVC5Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MvcApp.Tests.Controllers
{
    public class AsyncContronlerTests
    {
        /// <summary>
        /// TestAsync
        /// </summary>
        /// <returns></returns>
        /// <see cref="http://bradwilson.typepad.com/blog/2012/01/xunit19.html"/>
        [Fact]
        public async Task TestAsync()
        {
            //
            var controller = new EmployeeController();
            var result=await controller.Get(1);

            Assert.NotNull(result.Data);
       
        }

    }
}
