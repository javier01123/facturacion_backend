using Facturacion.Domain.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Facturacion.Domain.Aggregates;

namespace Domain.UnitTests.Aggregates.CfdiTests
{
    [TestFixture]
    public class ModificarPartida
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

            //valores iniciales de la partida
            _partidaId = Guid.NewGuid();
            var cantidad = 23.66m;
            var valorUnitario = 12.55m;
            var descripcion = "descripción para a partida";

            _cfdi = Cfdi.Create(id, clienteId,sucursalId, fechaEmision,serie,folio);
            _cfdi.AgregarPartida(_partidaId, cantidad, valorUnitario, descripcion);
        }
        //modificar partida
        [Test]
        public void ModificarPartida_DatosValidos_DebeGenerarElTotalEsperado()
        {
            //nuevos valores
            var nuevaCantidad = 2m;
            var nuevoValorUnitario = 1.32m;
            var nuevaDescripcion = "nueva descripción";
            var totalEsperado = 2.64m;

            //act
            _cfdi.ModificarPartida(_partidaId, nuevaCantidad, nuevoValorUnitario, nuevaDescripcion);

            //assert
            Assert.AreEqual(totalEsperado, _cfdi.Total);
        }

        [Test]
        public void ModificarPartida_CantidadEnCero_DebeLanzarEx()
        {
            //nuevos valores
            var nuevaCantidad = 0m;
            var nuevoValorUnitario = 1.32m;
            var nuevaDescripcion = "nueva descripción";

            //assert
            Assert.Throws<GenericDomainException>(() => _cfdi.ModificarPartida(_partidaId, nuevaCantidad, nuevoValorUnitario, nuevaDescripcion));
        }

        [Test]
        public void ModificarPartida_ValorUnitarioCero_DebeLanzarEx()
        {
            //nuevos valores
            var nuevaCantidad = 2m;
            var nuevoValorUnitario = 0m;
            var nuevaDescripcion = "nueva descripción";

            //assert
            Assert.Throws<GenericDomainException>(() => _cfdi.ModificarPartida(_partidaId, nuevaCantidad, nuevoValorUnitario, nuevaDescripcion));
        }

        [Test]
        public void ModificarPartida_DescripcionVacia_DebeLanzarEx()
        {
            //nuevos valores
            var nuevaCantidad = 2m;
            var nuevoValorUnitario = 0m;
            var nuevaDescripcion = "nueva descripción";

            //assert
            Assert.Throws<GenericDomainException>(() => _cfdi.ModificarPartida(_partidaId, nuevaCantidad, nuevoValorUnitario, nuevaDescripcion));
        }
    }
}
