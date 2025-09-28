using System.Security.Cryptography;
using System.Text;
using Backer.Utilities;
using Xunit;

namespace Backer.Web.Tests;

public class TokenUtilityTests
{
    [Fact]
    public void HashPassword_GeneratesVerifiableHash()
    {
        var password = "Pa$$w0rd!";

        var hash = TokenUtility.HashPassword(password);

        Assert.True(TokenUtility.VerifyPassword(password, hash));
        Assert.False(TokenUtility.VerifyPassword("incorrect", hash));
    }

    [Fact]
    public void VerifyPassword_SupportsLegacySha256Hashes()
    {
        var password = "legacy";
        var legacyHash = ComputeLegacyHash(password);

        Assert.True(TokenUtility.VerifyPassword(password, legacyHash));
        Assert.False(TokenUtility.VerifyPassword("wrong", legacyHash));
    }

    private static string ComputeLegacyHash(string password)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        var builder = new StringBuilder(bytes.Length * 2);
        foreach (byte b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }
}
