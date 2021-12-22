using System;

namespace Cryptography_SHA1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello World";

            SHA1Service service = new();

            var result= service.Hash(text);
            
            Console.WriteLine(String.Format("{0,-20} {1,-10}", "Text Before Hash", text ));

            Console.WriteLine(String.Format("{0,-20} {1,-10}", "Text Hashed", result));

            Console.ReadKey();

        }
    }
}
