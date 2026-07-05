using System.Security.Cryptography;
using System.Text;

namespace AssetCheckoutSystem.Helpers
{
    public static class EncryptionHelper
    {
        public static string ToSha256(string input) =>
            Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(input))
            );

        public static string GenerateRandomSha256() =>
            Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
    }
}