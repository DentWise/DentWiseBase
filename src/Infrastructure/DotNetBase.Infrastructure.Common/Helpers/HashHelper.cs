using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation; // PBKDF2 için

namespace DotNetBase.Infrastructure.Common.Helpers
{
    public static class HashHelper
    {
        public static string HashPassword(string password)
        {
            // Salt'ı otomatik olarak oluşturur ve hash'e dahil eder.
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
