using Facturacion.Domain.Aggregates;
using Facturacion.Domain.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.Aggregates.ClienteTests
{
    [TestFixture]
    public class CambiarRfc 
    {
        [Test]
        public void CambiarRfc_RfcValido_NoDebeLanzarEx()
        {
            var id = Guid.NewGuid();
            var empresaId = Guid.NewGuid();
            var rfc = "XAXX010101000";
            var razonSocial = "Cliente sa de cv";
            var cliente = Cliente.Create(id, empresaId, rfc, razonSocial);
            var nuevoRfc = "AAA010101AAA";

            Assert.DoesNotThrow(() => cliente.CorregirRfc(nuevoRfc));
        }

        [Test]
        public void CambiarRfc_RfInvalido_DebeLanzarEx()
        {
            var id = Guid.NewGuid();
            var empresaId = Guid.NewGuid();
            var rfc = "XAXX010101000";
            var razonSocial = "Cliente sa de cv";
            var cliente = Cliente.Create(id, empresaId, rfc, razonSocial);
            var nuevoRfc = "AAA999999AAA";

            Assert.Throws<RfcFormatoInvalidoException>(() => cliente.CorregirRfc(nuevoRfc));
        }

    }
}
