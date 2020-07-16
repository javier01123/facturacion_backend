using Facturacion.Domain.Aggregates;
using Facturacion.Domain.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.Aggregates.ClienteTests
{
    [TestFixture]
    public class CambiarRazonSocial
    {


        [Test]
        public void CambiarRazonSocial_RazonSocialValida_NoDebeLanzarEx()
        {
            var id = Guid.NewGuid();
            var empresaId = Guid.NewGuid();
            var rfc = "XAXX010101000";
            var razonSocial = "Cliente sa de cv";
            var cliente = Cliente.Create(id, empresaId, rfc, razonSocial);
            var nuevaRazonSocial = "Nueva razon social";

            Assert.DoesNotThrow(() => cliente.CambiarRazonSocial(nuevaRazonSocial));
        }

        [Test]
        public void CambiarRazonSocial_RazonSocialVacia_DebeLanzarEx()
        {
            var id = Guid.NewGuid();
            var empresaId = Guid.NewGuid();
            var rfc = "XAXX010101000";
            var razonSocial = "Cliente sa de cv";
            var cliente = Cliente.Create(id, empresaId, rfc, razonSocial);
            var nuevaRazonSocial = "";

            Assert.Throws<GenericDomainException>(() => cliente.CambiarRazonSocial(nuevaRazonSocial));
        }
    }
}
