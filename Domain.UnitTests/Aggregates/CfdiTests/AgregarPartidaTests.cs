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
    public class AgregarPartidaTests
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
        public void agregar_partida_debe_calcular_totales()
        {
            var partidaId = Guid.NewGuid();
            var cantidad = 23.66m;
            var valorUnitario = 12.55m;
            var descripcion = "despcripción para a partida";
            var tasaIva = 16;

            var subtotalEsperado = 296.93m;
            var ivaEsperado =47.51m ;
            var totalEsperado =344.44m;          

            //act
            _cfdi.AgregarPartida(partidaId, cantidad, valorUnitario, descripcion);
            _cfdi.AsignarTasaIva(tasaIva);

            //assert
            Assert.AreEqual(subtotalEsperado, _cfdi.Subtotal);
            Assert.AreEqual(ivaEsperado, _cfdi.Iva);
            Assert.AreEqual(totalEsperado, _cfdi.Total);
            
        }

        [Test]
        public void partida_con_cantidad_cero_debe_lanzar_excepcion()
        {
            var partidaId = Guid.NewGuid();
            var cantidad = 0m;
            var valorUnitario = 12.55m;
            var descripcion = "despcripción para a partida";
 
            Assert.Throws<InvalidParameterException>(() =>
            _cfdi.AgregarPartida(partidaId, cantidad, valorUnitario, descripcion));
        }

        [Test]
        public void agregar_valor_unitario_cero_debe_lanzar_excepcion()
        {
            var partidaId = Guid.NewGuid();
            var cantidad = 1m;
            var valorUnitario = 0m;
            var descripcion = "despcripción para a partida";
        
            Assert.Throws<InvalidParameterException>(() =>
            _cfdi.AgregarPartida(partidaId, cantidad, valorUnitario, descripcion));
        }

        [Test]
        public void agregar_partida_sin_descripcion_debe_lanzar_excepcion()
        {
            var partidaId = Guid.NewGuid();
            var cantidad = 1m;
            var valorUnitario = 1m;
            var descripcion = " ";         

            Assert.Throws<InvalidParameterException>(() =>
            _cfdi.AgregarPartida(partidaId, cantidad, valorUnitario, descripcion));
        }

    }
}
