using Facturacion.Infrastructure.Hashing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrasctructure.UnitTests.Hashing
{
    [TestFixture]
    public class PasswordHasherTests
    {
        private PasswordHasher _passwordHasher;

        [SetUp]
        public void SetUp()
        {
            _passwordHasher = new PasswordHasher();
        }

        [Test]
        public void GenerateSalt_DebeRegresarNoNulo()
        {
            var salt = _passwordHasher.GenerateSalt();
            Assert.NotNull(salt);
        }

        [Test]
        public void HashPassword_SaltPredefinido_DebeRegresarResultadoDefinido()
        {
            var salt = "dm1/Vgoz/Ju1N4ROyNwWdw==";
            var password = "1123456";
            var resultadoEsperado = "aY5N8lYbsDFRcVL4ZIGg0wd9H6mHchTrB+SQN5jDnH8=";

            var resultado = _passwordHasher.HashPassword(salt, password);

            Assert.AreEqual(resultadoEsperado, resultado);
        }


        [Test]
        public void VerifyPassword_SaltPredefinido_DebeRegresarResultadoDefinido()
        {
            var salt = "dm1/Vgoz/Ju1N4ROyNwWdw==";
            var password = "1123456";
            var hashedPassword = "aY5N8lYbsDFRcVL4ZIGg0wd9H6mHchTrB+SQN5jDnH8=";

            bool resultado = _passwordHasher.VerifyPassword(password, salt + ":" + hashedPassword);

            Assert.IsTrue(resultado);
        }

    }
}
