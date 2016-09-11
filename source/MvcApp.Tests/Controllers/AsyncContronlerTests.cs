// ***********************************************************************
// Assembly         : MvcApp.Tests
// Author           : Peter Liu
// Created          : 04-03-2015
//
// Last Modified By : Peter Liu
// Last Modified On : 09-11-2016
// ***********************************************************************
// <copyright file="AsyncContronlerTests.cs" company="Microsoft">
//     Copyright © Microsoft 2011
// </copyright>
// <summary></summary>
// ***********************************************************************
using MVC5Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// The Controllers namespace.
/// </summary>
namespace MvcApp.Tests.Controllers
{
    /// <summary>
    /// Class AsyncContronlerTests.
    /// </summary>
    public class AsyncContronlerTests
    {
        /// <summary>
        /// TestAsync
        /// </summary>
        /// <returns>Task.</returns>
        /// <see cref="http://bradwilson.typepad.com/blog/2012/01/xunit19.html" />
        public async Task TestAsync()
        {
            var controller = new EmployeeController();
            var result=await controller.Get(1);

            Assert.NotNull(result.Data);
       
        }

    }
}
