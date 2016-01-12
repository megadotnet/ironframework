using IronFramework.Common.Config;
using System;
using System.Globalization;

namespace BusinessObject.Auth
{
    public class AccountRepository : IAccountRepository
    {
        /// <summary>
        /// Gets the hashed password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public string GetHashedPassword(string username)
        {
            //Should get from database
            return SecurityConfig.Password;
        }

    }
}
