using Facturacion.Domain.Aggregates;
using Facturacion.Domain.Exceptions;
using NSubstitute.Proxies.CastleDynamicProxy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.Aggregates.CfdiTests
{
    [TestFixture]
    public class Create
    {
        [Test]
        public void Create_DatosValidos_NoDebeLanzarEx()
        {
            var id = Guid.NewGuid();
            var clienteId = Guid.NewGuid();
            var sucursalId = Guid.NewGuid();
            var fechaEmision = DateTime.Now;
            var serie = "f";
            var folio = 1;

            Assert.DoesNotThrow(() => Cfdi.Create(id, clienteId,sucursalId, fechaEmision,serie,folio));
        }

        [Test]
        public void Create_IdVacio_DebeLanzarEx()
        {
            var id = Guid.Empty;
            var clienteId = Guid.NewGuid();
            var sucursalId = Guid.NewGuid();
            var fechaEmision = DateTime.Now;
            var serie = "f";
            var folio = 1;

            Assert.Throws<GenericDomainException>(() => Cfdi.Create(id, clienteId,sucursalId, fechaEmision,serie,folio));
        }

        [Test]
        public void Create_ClienteIdVacio_DebeLanzarEx()
        {
            var id = Guid.NewGuid();
            var clienteId = Guid.Empty;
            var sucursalId = Guid.NewGuid();
            var fechaEmision = DateTime.Now;
            var serie = "f";
            var folio = 1;

            Assert.Throws<GenericDomainException>(() => Cfdi.Create(id, clienteId,sucursalId, fechaEmision,serie,folio));
        }
 
    }
}
