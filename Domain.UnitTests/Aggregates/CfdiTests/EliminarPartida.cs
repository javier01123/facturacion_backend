using Facturacion.Domain.Aggregates;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.Aggregates.CfdiTests
{
    [TestFixture]
    public class EliminarPartida
    {
        private Guid _partidaId;
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

            _partidaId = Guid.NewGuid();
            var cantidad = 23.66m;
            var valorUnitario = 12.55m;
            var descripcion = "descripción para a partida";

            _cfdi = Cfdi.Create(id, clienteId, sucursalId, fechaEmision,serie,folio);
            _cfdi.AgregarPartida(_partidaId, cantidad, valorUnitario, descripcion);
        }

        [Test]
        public void IdsExistentes_NoDebeLanzarEx()
        {
            Assert.DoesNotThrow(() => _cfdi.EliminarPartida(_partidaId));
        }
    }
}
