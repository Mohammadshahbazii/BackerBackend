using System;
using Backer.Core.Interfaces;
using Backer.Utilities;
using Microsoft.Extensions.Configuration;

namespace Backer.Infrastructure.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string username)
        {
            return TokenUtility.GenerateToken(
                key: _configuration["Jwt:Key"],
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                username: username,
                tokenValidityInMinutes: Convert.ToDouble(_configuration["Jwt:TokenValidityInMinutes"])
            );
        }

        public string HashPassword(string password)
        {
            return TokenUtility.HashPassword(password);
        }

        public bool VerifyPassword(string password, string storedHash)
        {
            return TokenUtility.VerifyPassword(password,storedHash);
        }
    }
}
