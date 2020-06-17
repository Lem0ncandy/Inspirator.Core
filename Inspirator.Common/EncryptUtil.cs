using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Inspirator.Common
{
    public class EncryptUtil
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="source">原文</param>
        /// <returns>密文</returns>
        public static string Encrypt(string source)
        {
            using MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            StringBuilder builder = new StringBuilder();
            foreach (byte bt in data)
            {
                builder.Append(bt.ToString("x2"));
            }
            string hash = builder.ToString();
            return hash.ToUpper();
        }

        public static bool Verify(string cipher, string password)
        {
            return cipher == Encrypt(password);
        }
    }
}
