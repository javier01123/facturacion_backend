using Facturacion.Domain.Exceptions;
using Facturacion.Domain.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.ValueObjects
{
    [TestFixture]
    public class RfcTests
    {
        [Test]
        public void Create_RfcValido_NoDebeLanzarEx()
        {
            string rfc = "XAXX010101000";
            Assert.DoesNotThrow(() => Rfc.For(rfc));
        }

        [Test]
        public void For_RfcInvalido_DebeLanzarEx()
        {
            string rfc = "XAXX999999000";
            Assert.Throws<RfcFormatoInvalidoException>(() => Rfc.For(rfc));
        }


    }
}
