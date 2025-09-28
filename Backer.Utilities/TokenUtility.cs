using System;
using System.Buffers.Binary;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Backer.Utilities
{
    public static class TokenUtility
    {
        // Existing token generation method.
        public static string GenerateToken(
            string key,
            string issuer,
            string audience,
            string username,
            double tokenValidityInMinutes)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100_000;
        private const byte HashVersion = 1;

        /// <summary>
        /// Hashes a password using PBKDF2 with a random salt and embeds the
        /// metadata required for verification in a Base64 encoded payload.
        /// </summary>
        /// <param name="password">The plaintext password to hash.</param>
        /// <returns>A Base64 encoded string containing the hashing metadata, salt and derived key.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="password"/> is null.</exception>
        public static string HashPassword(string password)
        {
            if (password is null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] derivedKey = pbkdf2.GetBytes(KeySize);

            byte[] payload = new byte[1 + sizeof(int) + SaltSize + KeySize];
            payload[0] = HashVersion;
            BinaryPrimitives.WriteInt32BigEndian(payload.AsSpan(1, sizeof(int)), Iterations);
            Buffer.BlockCopy(salt, 0, payload, 1 + sizeof(int), SaltSize);
            Buffer.BlockCopy(derivedKey, 0, payload, 1 + sizeof(int) + SaltSize, KeySize);

            return Convert.ToBase64String(payload);
        }

        /// <summary>
        /// Verifies a plaintext password against either the new PBKDF2 based payload
        /// or the legacy SHA-256 hex encoded hash.
        /// </summary>
        /// <param name="password">The plaintext password to validate.</param>
        /// <param name="storedHash">The stored hash to validate against.</param>
        /// <returns><c>true</c> when the password matches the stored hash; otherwise <c>false</c>.</returns>
        public static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(storedHash))
            {
                return false;
            }

            if (TryVerifyPbkdf2(password, storedHash, out bool verified))
            {
                return verified;
            }

            string legacyHash = HashPasswordLegacy(password);
            return string.Equals(legacyHash, storedHash, StringComparison.OrdinalIgnoreCase);
        }

        private static bool TryVerifyPbkdf2(string password, string storedHash, out bool verified)
        {
            verified = false;

            byte[] hashBytes;
            try
            {
                hashBytes = Convert.FromBase64String(storedHash);
            }
            catch (FormatException)
            {
                return false;
            }

            int expectedLength = 1 + sizeof(int) + SaltSize + KeySize;
            if (hashBytes.Length != expectedLength || hashBytes[0] != HashVersion)
            {
                return false;
            }

            int iterations = BinaryPrimitives.ReadInt32BigEndian(hashBytes.AsSpan(1, sizeof(int)));
            if (iterations <= 0)
            {
                return false;
            }

            byte[] salt = new byte[SaltSize];
            Buffer.BlockCopy(hashBytes, 1 + sizeof(int), salt, 0, SaltSize);

            byte[] storedSubKey = new byte[KeySize];
            Buffer.BlockCopy(hashBytes, 1 + sizeof(int) + SaltSize, storedSubKey, 0, KeySize);

            try
            {
                using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
                byte[] generatedSubKey = pbkdf2.GetBytes(KeySize);

                verified = CryptographicOperations.FixedTimeEquals(storedSubKey, generatedSubKey);
                return true;
            }
            catch (CryptographicException)
            {
                return false;
            }
        }

        private static string HashPasswordLegacy(string password)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
