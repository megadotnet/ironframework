// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CachingCallHandlerAttribute.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The caching call handler attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTest.TestUtility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Xunit;
    using IronFramework.Utility;

    /// <summary>
    /// TestSingleton
    /// </summary>
    public class TestSingleton
    {
       /// <summary>
       /// Commons the test.
       /// </summary>
       [Fact]
       public void CommonTest()
       {
           Customer customer1 = Singleton.GetInstance<Customer>();
           Customer customer2 = Singleton.GetInstance<Customer>();
            Assert.Same(customer1, customer2);
        }
 
 
        /// <summary>
        /// Anonymouses this instance.
        /// </summary>
        [Fact]
        public void Anonymous()
        {
            Customer customer1 = Singleton.GetInstance<Customer>(delegate() { return new Customer();});
            Customer customer2 = Singleton.GetInstance<Customer>(delegate() { return new Customer(); });
            Assert.Same(customer1,customer2);
        }
 
        /// <summary>
        /// Usings the lambda.
        /// </summary>
        [Fact]
        public void UsingLambda()
        {
            Customer customer1 = Singleton.GetInstance<Customer>(() => new Customer());
            Customer customer2 = Singleton.GetInstance<Customer>(() => new Customer());
            Assert.Same(customer1, customer2);
        }
    }
}
