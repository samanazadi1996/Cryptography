using Cryptography_AES;
using Cryptography_RSA;
using Xunit;

namespace Test.Cryptography
{
    public class Cryptography_RSA_Test
    {
        [Theory]
        [InlineData("Test" )]
        [InlineData("Test2")]
        public void Test_String(string text)
        {
            RSAService service = new();

            var resultEncrypt = service.Encrypt(text);
            var resultDecrypt = service.Decrypt(resultEncrypt);

            Assert.Equal(text, resultDecrypt);
        }
    }
}
