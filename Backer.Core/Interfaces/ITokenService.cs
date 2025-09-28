using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string username);
        string HashPassword(string password);
        bool VerifyPassword(string password, string storedHash);
    }
}

