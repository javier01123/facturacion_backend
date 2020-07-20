using Facturacion.Domain.Aggregates;
using Facturacion.Domain.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.Aggregates.ClienteTests
{
    [TestFixture]
    public class Create
    {

        [Test]
        public void Create_DatosValidos_DebeGenerarClienteConDatosEspecificados()
        {
            var id = Guid.NewGuid();
            var empresaId = Guid.NewGuid();
            var rfc = "XAXX010101000";
            var razonSocial = "Cliente sa de cv";

            var cliente = Cliente.Create(id, empresaId, rfc, razonSocial);

            Assert.AreEqual(cliente.Id, id);
            Assert.AreEqual(cliente.EmpresaId, empresaId);
        }

        [Test]
        public void Create_IdVacio_DebeLanzarEx()
        {
            var id = Guid.Empty;
            var empresaId = Guid.NewGuid();
            var rfc = "XAXX010101000";
            var razonSocial = "Cliente sa de cv";

            Assert.Throws<InvalidParameterException>(() => Cliente.Create(id, empresaId, rfc, razonSocial));
        }

        [Test]
        public void Create_IdEmpresaVacio_DebeLanzarEx()
        {
            var id = Guid.NewGuid();
            var empresaId = Guid.Empty;
            var rfc = "XAXX010101000";
            var razonSocial = "Cliente sa de cv";

            Assert.Throws<InvalidParameterException>(() => Cliente.Create(id, empresaId, rfc, razonSocial));
        }


        [Test]
        public void Create_RazonSocialVacia_DebeLanzarEx()
        {
            var id = Guid.NewGuid();
            var empresaId = Guid.NewGuid();
            var rfc = "XAXX010101000";
            var razonSocial = "";

            Assert.Throws<InvalidParameterException>(() => Cliente.Create(id, empresaId, rfc, razonSocial));
        }

        [Test]
        public void Create_RazonSocialConEspacios_DebeLanzarEx()
        {
            var id = Guid.NewGuid();
            var empresaId = Guid.NewGuid();
            var rfc = "XAXX010101000";
            var razonSocial = "    ";

            Assert.Throws<InvalidParameterException>(() => Cliente.Create(id, empresaId, rfc, razonSocial));
        }

    }
}
