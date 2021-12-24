using PemUtils;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography_RSA
{
    public class RSAService
    {
        private readonly Encoding encoding;
        public RSAService()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            encoding = Encoding.GetEncoding("IBM00858");
        }
        public string Encrypt(string data)
        {
            var privateRsa = GetRsa("Public.Key");

            var cipherTextBytes = privateRsa.Encrypt(encoding.GetBytes(data), RSAEncryptionPadding.OaepSHA1);

            return encoding.GetString(cipherTextBytes);
        }

        public string Decrypt(string encryptedData)
        {
            var privateRsa = GetRsa("Private.Key");

            var dataBytes = privateRsa.Decrypt(encoding.GetBytes(encryptedData), RSAEncryptionPadding.OaepSHA1);

            return encoding.GetString(dataBytes);
        }
        private static RSA GetRsa(string fileName)
        {
            using (var privateKey = File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), "Keys", fileName)))
            {
                using (var pem = new PemReader(privateKey))
                {
                    var rsaParameters = pem.ReadRsaKey();
                    return RSACryptoServiceProvider.Create(rsaParameters);
                }
            }
        }
    }
}