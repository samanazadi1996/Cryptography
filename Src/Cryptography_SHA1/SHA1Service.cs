using System;
using System.Text;
using XSystem.Security.Cryptography;

namespace Cryptography_SHA1
{
    public class SHA1Service
    {
        public string Hash(string stringToHash)
        {
            using (var sha1 = new SHA1Managed())
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(stringToHash)));
        }

    }
}
