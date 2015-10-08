using IronFramework.Common.Config;
using System;
using System.Globalization;

namespace BusinessObject.Auth
{
    public class AccountRepository : IAccountRepository
    {
        public string GetHashedPassword(string username)
        {
            //Should get from database
            return SecurityConfig.Password;
        }

    }
}
