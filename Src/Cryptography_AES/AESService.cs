﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography_AES
{
    public class AESService
    {
        private readonly string Key;
        public AESService(string key)
        {
            Key = key;
        }
        public string Encrypt(string text)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(text);
                        }
                        array = memoryStream.ToArray();
                        return Convert.ToBase64String(array);
                    }
                }
            }

        }
        public string Decrypt(string text)
        {
            byte[] iv = new byte[16];
            text = text.Replace(" ", "+");
            byte[] buffer = Convert.FromBase64String(text);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }

        }

    }

}
