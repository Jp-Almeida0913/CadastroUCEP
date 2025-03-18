using Microsoft.AspNetCore.Identity;

namespace CadastroUCEP.Class
{
    public class HashPassword
    {
        private readonly PasswordHasher<string> _passwordHasher = new();

        public string GeneratePassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}