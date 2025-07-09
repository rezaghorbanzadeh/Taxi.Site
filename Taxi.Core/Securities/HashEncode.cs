using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Security.Cryptography;

namespace Taxi.Core.Securities
{
    public static class HashEncode
    {

        public static string GetHashCode(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256).GetBytes(32);

            byte[] result = new byte[48];
            Buffer.BlockCopy(salt, 0, result, 0, 16);
            Buffer.BlockCopy(hash, 0, result, 16, 32);

            return Convert.ToBase64String(result);
        }

        public static bool Verify(string password, string stored)
        {
            byte[] data = Convert.FromBase64String(stored);
            byte[] salt = new byte[16];
            Buffer.BlockCopy(data, 0, salt, 0, 16);

            byte[] hash = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256).GetBytes(32);

            for (int i = 0; i< 32; i++)
                if (data[i + 16] != hash[i]) return false;

            return true;
        }
    }
}
