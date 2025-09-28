using System;
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

        /// Hashes a password using PBKDF2 with a random salt.
        /// The returned string contains both the salt and hash in Base64 format.
        public static string HashPassword(string password)
        {
            // Convert the integer to a stringk
            string passwordString = password.ToString();
            // Use SHA-256 to hash the password string
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(passwordString));
                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// Verifies a plaintext password against the stored Base64-encoded salt and hash.
        public static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            if (string.IsNullOrWhiteSpace(storedHash))
                return false;

            // Extract the bytes from the stored hash.
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // The salt is the first 16 bytes.
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, salt.Length);

            // Generate a hash from the provided password using the same salt and iteration count.
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32);

                // Compare the computed hash with the stored hash.
                for (int i = 0; i < hash.Length; i++)
                {
                    if (hashBytes[i + salt.Length] != hash[i])
                        return false;
                }
                return true;
            }
        }
    }
}
