using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IronFramework.Utility
{
    public class VerifyTransactionSN
    {

        /// <summary>
        /// Gets the hash string.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>string</returns>
        public static string GetHashString(string username, string password)
        {
            string salt = username;
            byte[] passwordAndSaltBytes = System.Text.Encoding.UTF8.GetBytes(password + salt);
            byte[] hashBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordAndSaltBytes);
            string hashString = Convert.ToBase64String(hashBytes);
            return hashString;
        }

        #region "生成交易标记号"
        /// <summary>
        /// 生成交易标记号
        /// </summary>
        /// <param name="FirstPhoneNumber">第一个号码</param>
        /// <returns>返回一个20位长的字符串</returns>
        public static string BuildTransactionSN(string FirstPhoneNumber)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            return Hex(md5.ComputeHash(Encoding.ASCII.GetBytes(
                FirstPhoneNumber + DateTime.Now.ToString("MMddHHmmss") + FirstPhoneNumber + GetNewGuid()
                ))).Substring(0, 20).ToUpper();

        }

        #endregion


        #region GenerateTranscationSN 
        /// <summary>
        /// Generates the sn 随机数字20位
        /// </summary>
        /// <param name="phonenumber">The phonenumber.</param>
        /// <returns>string</returns>
        public static string GenerateSN(string phonenumber)
        {
            string target = GetRandomIntFromByte(phonenumber) + GenerateRandomInt((int)DateTime.Now.Ticks).ToString();
            return target.Substring(0, 20);
        }

        /// <summary>
        /// Generates the random int.
        /// </summary>
        /// <returns>int</returns>
        public static int GenerateRandomInt()
        {
            int seed1 = (int)DateTime.Now.Ticks;
            return GenerateRandomInt(seed1);
        }

        /// <summary>
        /// Generates the random int.
        /// </summary>
        /// <param name="seed1">The seed1.</param>
        /// <returns>int</returns>
        public static int GenerateRandomInt(int seed1)
        {
            var rnd = new Random(seed1);
            return rnd.Next(0, int.MaxValue);
        }

        /// <summary>
        /// Gets the random int from byte.
        /// </summary>
        /// <param name="phonenumber">The phonenumber.</param>
        /// <returns>UInt64</returns>
        public static UInt64 GetRandomIntFromByte(string phonenumber)
        {
            var seed = Encoding.Default.GetBytes(phonenumber);
            new RNGCryptoServiceProvider().GetBytes(seed);
            return BitConverter.ToUInt64(seed, 0);
        }

        #endregion

        #region "转换为16进制"
        /// <summary>
        /// 转换为16进制.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string Hex(byte[] s)   //
        {
            string ret = "";
            for (int i = 0; i < 16; i++)
            {
                ret += s[i].ToString("x2");
            }
            return ret;
        }

        #endregion

        #region 动态生成GUID
        //动态生成GUID 
        public static string GetNewGuid()
        {
            return System.Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        }
        #endregion

        /// <summary>
        /// BuildSISMSID 生成一段随机字符串
        /// </summary>
        /// <returns></returns>
        public static string BuildSISMSID()
        {
            DateTime dt = DateTime.Now;
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            return Hex(md5.ComputeHash(Encoding.ASCII.GetBytes(dt.ToString("MMddHHmmss") + GetNewGuid()))).Substring(0, 30).ToUpper();

        } 


    }
}
