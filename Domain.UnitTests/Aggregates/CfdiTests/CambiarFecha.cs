using Facturacion.Domain.Aggregates;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.Aggregates.CfdiTests
{
    public class CambiarFecha
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
        public void CambiarFecha_NoDebeLanzarEx()
        {
            var nuevaFechaEmision = DateTime.Now;
            _cfdi.CambiarFechaEmision(nuevaFechaEmision);
        }
    }
}
