using Cryptography_SHA1;
using Xunit;

namespace Test.Cryptography
{
    public class Cryptography_SHA1_Test
    {
        [Theory]
        [InlineData("Test", "64-0A-B2-BA-E0-7B-ED-C4-C1-63-F6-79-A7-46-F7-AB-7F-B5-D1-FA")]
        [InlineData("Test2", "2B-84-F6-21-C0-FD-4B-A8-BD-51-4C-5C-43-AB-9A-89-7C-8C-01-4E")]
        public void Test_Hash_String(string text, string result)
        {
            SHA1Service service = new();

            var serviceResult = service.Hash(text);

            Assert.Equal(serviceResult, result);
        }
    }
}
