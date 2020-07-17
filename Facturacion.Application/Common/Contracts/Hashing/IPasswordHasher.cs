namespace Facturacion.Application.Common.Contracts.Hashing
{
    public interface IPasswordHasher
    {
        string GenerateSalt();
        string HashPassword(string saltb64, string password);
        bool VerifyPassword(string passwordToVerify, string passwordWithSalt);
    }
}