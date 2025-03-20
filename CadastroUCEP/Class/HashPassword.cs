using Microsoft.AspNetCore.Identity;
using System;

namespace CadastroUCEP.Class
{
    public class HashPassword
    {
        private readonly PasswordHasher<object> _passwordHasher = new();
        public string GeneratePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("A senha não pode ser vazia.", nameof(password));

            return _passwordHasher.HashPassword(null, password);
        }
        public bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hashedPassword))
                return false;

            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}