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
    public class AgregarPartida
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
        public void AgregarPartida_DatosValidos_DebeGenerarElTotalEsperado()
        {
            var partidaId = Guid.NewGuid();
            var cantidad = 23.66m;
            var valorUnitario = 12.55m;
            var descripcion = "despcripción para a partida";
            var totalEsperado = 296.93m;

            //act
            _cfdi.AgregarPartida(partidaId, cantidad, valorUnitario, descripcion);

            //assert
            Assert.AreEqual(totalEsperado, _cfdi.Total);
        }

        [Test]
        public void AgregarPartida_CantidadEnCero_DebeLanzarEx()
        {
            var partidaId = Guid.NewGuid();
            var cantidad = 0m;
            var valorUnitario = 12.55m;
            var descripcion = "despcripción para a partida";
 
            Assert.Throws<GenericDomainException>(() =>
            _cfdi.AgregarPartida(partidaId, cantidad, valorUnitario, descripcion));
        }

        [Test]
        public void AgregarPartida_ValorUnitarioCero_DebeLanzarEx()
        {
            var partidaId = Guid.NewGuid();
            var cantidad = 1m;
            var valorUnitario = 0m;
            var descripcion = "despcripción para a partida";
        
            Assert.Throws<GenericDomainException>(() =>
            _cfdi.AgregarPartida(partidaId, cantidad, valorUnitario, descripcion));
        }

        [Test]
        public void AgregarPartida_DescripcionVacia_DebeLanzarEx()
        {
            var partidaId = Guid.NewGuid();
            var cantidad = 1m;
            var valorUnitario = 1m;
            var descripcion = " ";         

            Assert.Throws<GenericDomainException>(() =>
            _cfdi.AgregarPartida(partidaId, cantidad, valorUnitario, descripcion));
        }

    }
}
