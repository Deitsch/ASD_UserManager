using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            byte[] hashValue;

            UnicodeEncoding ue = new UnicodeEncoding();

            byte[] messageBytes = ue.GetBytes(password);

            SHA256 shHash = SHA256.Create();

            hashValue = shHash.ComputeHash(messageBytes);

            return ue.GetString(hashValue);
        }
    }
}
