using Facturacion.Domain.Aggregates;
using Facturacion.Domain.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.Aggregates.CfdiTests
{

    [TestFixture]
    public class AsignarTasaIva
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
            var partidaId = Guid.NewGuid();
            var cantidad = 1;
            var valorUnitario = 200;
            var descripcion = "despcripción para a partida";


            _cfdi = Cfdi.Create(id, clienteId, sucursalId, fechaEmision, serie, folio);
            _cfdi.AgregarPartida(partidaId, cantidad, valorUnitario, descripcion);
        }



        [TestCase(-1)]
        [TestCase(-0.01)]
        public void AsignarTasaIva_TasaNegativaDebeLanzarEx(decimal tasaIva)
        {
            Assert.Throws<InvalidParameterException>(() => _cfdi.AsignarTasaIva(tasaIva));
        }

        [TestCase(16, 32)]
        [TestCase(8, 16)]
        [TestCase(66.66, 133.32)]
        public void AsignarTasaIva_DebeRecalcularElImporteDelIva(decimal tasaIva, decimal IvaEsperado)
        {
            _cfdi.AsignarTasaIva(tasaIva);

            Assert.AreEqual(IvaEsperado, _cfdi.Iva);
        }

    }
}
