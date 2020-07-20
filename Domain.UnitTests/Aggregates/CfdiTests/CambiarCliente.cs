using Facturacion.Domain.Aggregates;
using Facturacion.Domain.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.Aggregates.CfdiTests
{
    [TestFixture]
    public class CambiarCliente
    {
        private Cfdi _cfdi;

        [SetUp]
        public void SetUp()
        {
            var id = Guid.NewGuid();
            var clienteId = Guid.NewGuid();
            var sucursalId = Guid.NewGuid();
            var fechaEmision = DateTime.Now;
            var serie = "f";
            var folio = 1;

            _cfdi = Cfdi.Create(id, clienteId,sucursalId, fechaEmision,serie,folio);
        }

        [Test]
        public void CambiarCliente_IdValid_NoDebeLanzarEx()
        {
            var nuevoClienteId = Guid.NewGuid();
            Assert.DoesNotThrow(() => _cfdi.CambiarCliente(nuevoClienteId));
        }

        [Test]
        public void CambiarCliente_IdVacio_DebeLanzarEx()
        {
            var nuevoClienteId = Guid.Empty;
            Assert.Throws<InvalidParameterException>(() => _cfdi.CambiarCliente(nuevoClienteId));
        }
    }
}
