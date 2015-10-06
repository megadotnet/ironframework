using System;
using System.Globalization;

namespace WebApi2
{
    public class AccountRepository : IAccountRepository
    {
        public string GetHashedPassword(string username)
        {
            return "password";
        }

        //public void TestDateTime()
        //{
        //    string timestampString = DateTime.UtcNow.ToString("u");

        //    Console.WriteLine(timestampString);

        //    DateTime timestamp;

        //    bool isDateTime = DateTime.TryParseExact(timestampString, "u", null,
        //        DateTimeStyles.AdjustToUniversal, out timestamp);

        //    Console.WriteLine(isDateTime);

        //}
    }
}
