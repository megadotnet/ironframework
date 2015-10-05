using IronFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Infrastructure
{
    /// <summary>
    /// SecurityTest
    /// </summary>
    public class SecurityTest
    {
        /// <summary>
        /// bs the crypt test.
        /// </summary>
        [Fact]
        public void BCryptTest()
        {
            string password = "PASSWORD";
            int workFactor = 13;

            var start = DateTime.UtcNow;

            var hashed = VerifyTransactionSN.GenerateVariantHashString(password, workFactor);
            var end = DateTime.UtcNow;

            Console.WriteLine("hash length is {0} chars", hashed.Length);
            Console.WriteLine("Processing time is {0} with workFactor {1}", end - start, workFactor);
            Console.WriteLine("Hashed password: {0} ", hashed);
            Console.WriteLine("correct password {0}", VerifyTransactionSN.VerifyVariantHash("PASSWORD", hashed));
            Console.WriteLine("incorrect password {0}", VerifyTransactionSN.VerifyVariantHash("PASSWORd", hashed));

            Assert.True(VerifyTransactionSN.VerifyVariantHash("PASSWORD", hashed));
        }
    }
}
