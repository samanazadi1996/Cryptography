using Cryptography_AES;
using Xunit;

namespace Test.Cryptography
{
    public class Cryptography_AES_Test
    {
        [Theory]
        [InlineData("Test", "T5byar2OLr6UW2DVVNkATA==", "12345678123456781234567812345678")]
        [InlineData("Test2", "eLdXraWkACP+wcuntvzq5Q==", "12345678123456781234567812345678")]
        public void Test_Encript_String(string text, string result, string key)
        {
            AESService service = new(key);

            var resultEncrypt = service.Encrypt(text);

            Assert.Equal(resultEncrypt, result);
        }

        [Theory]
        [InlineData("T5byar2OLr6UW2DVVNkATA==", "Test", "12345678123456781234567812345678")]
        [InlineData("eLdXraWkACP+wcuntvzq5Q==", "Test2", "12345678123456781234567812345678")]
        public void Test_Decrypt_String(string textEncrypted, string result, string key)
        {
            AESService service = new(key);

            var resultDecrypt = service.Decrypt(textEncrypted);

            Assert.Equal(resultDecrypt, result);
        }
    }
}
