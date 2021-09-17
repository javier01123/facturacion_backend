using Facturacion.Application.Common.Contracts.Hashing;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace Facturacion.Infrastructure.Hashing
{
    public class PasswordHasher : IPasswordHasher
    {
        public string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        public string HashPassword(string saltb64, string password)
        {
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: System.Text.Encoding.UTF8.GetBytes(saltb64),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public bool VerifyPassword(string passwordToVerify, string passwordWithSalt)
        {
            string[] splited = passwordWithSalt.Split(":", StringSplitOptions.None);

            if (splited.Length != 2)
                return false;

            string salt = splited[0];
            string hashInDb = splited[1];
            var hashResult = HashPassword(salt, passwordToVerify);
            int result = hashResult.CompareTo(hashInDb);
            return result == 0;
        }
    }
}
