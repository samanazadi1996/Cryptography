using System;

namespace Cryptography_AES
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = "12345678123456781234567812345678";

            Console.WriteLine(String.Format("{0,-20} {1,-10}", "Cryptography Key", key));

            string text = "Hello World";

            Console.WriteLine(String.Format("{0,-20} {1,-10}", "Text Befor Encrypt", text));
          
            AESService service = new(key);  //32 char key

            var resultEncrypt = service.Encrypt(text);
            Console.WriteLine(String.Format("{0,-20} {1,-10}", "Text Encrypted", resultEncrypt));

            var resultDecrypt = service.Decrypt(resultEncrypt);
            Console.WriteLine(String.Format("{0,-20} {1,-10}", "Text Decrypted", resultDecrypt));

            Console.ReadKey();
        }
    }

}
