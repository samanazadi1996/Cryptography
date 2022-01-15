using System;

namespace Cryptography_Blowfish
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "Blowfish Key";

            Console.WriteLine(String.Format("{0,-20} {1,-10}", "Cryptography Key", key));

            string text = "Hello World";

            Console.WriteLine(String.Format("{0,-20} {1,-10}", "Text Befor Encrypt", text));

            Blowfish service = new(key); 

            var resultEncrypt = service.EncryptBytes(text);
            Console.WriteLine(String.Format("{0,-20} {1,-10}", "Text Encrypted", resultEncrypt));

            var resultDecrypt = service.DecryptBytes(resultEncrypt);
            Console.WriteLine(String.Format("{0,-20} {1,-10}", "Text Decrypted", resultDecrypt));

            Console.ReadKey();
        }
    }
}
