using System;
using System.Security.Cryptography;
using System.Text;

namespace HelpDesk.Common
{
    public class PasswordEncryptor
    {
        public static string Encryptor(string password)
        {
            using var md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }
    }
}
