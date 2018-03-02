using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IronFramework.Utility.Security
{
    /// <summary>
    /// HashManager
    /// </summary>
    public class HashManager
    {
        /// <summary>
        /// Compute the hash with HMAC
        /// </summary>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static string ComputeHash(string hashedPassword, string message)
        {
            var key = Encoding.UTF8.GetBytes(hashedPassword.ToUpper());
            string hashString;

            using (var hmac = new HMACSHA256(key))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                hashString = Convert.ToBase64String(hash);
            }

            return hashString;
        }
    }
}
