using System;

namespace Cryptography_RSA
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string text = "Hello World";

            Console.WriteLine(String.Format("{0,-20} {1,-10}", "Text Befor Encrypt", text));

            RSAService service = new();

            var resultEncrypt = service.Encrypt(text);
            Console.WriteLine(String.Format("{0,-20} {1,-10}", "Text Encrypted", resultEncrypt));

            var resultDecrypt = service.Decrypt(resultEncrypt);
            Console.WriteLine(String.Format("{0,-20} {1,-10}", "Text Decrypted", resultDecrypt));

            Console.ReadKey();

        }
    }
}
