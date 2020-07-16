using Facturacion.Domain.Aggregates;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.Aggregates.SucursalTests
{
    [TestFixture]
    public class ActualizarDomicilio
    {
        private Sucursal _sucursal;

        [SetUp]
        public void SetUp()
        {
            var id = Guid.NewGuid();
            var empresaId = Guid.NewGuid();
            var nombre = "Sucursal prueba";
            _sucursal = Sucursal.Create(id, empresaId, nombre);
        }

        public void ActualizarDomicilio_DomicilioValido_NoDebeLanzarEx()
        {
            string pais = "México";
            string estado = "Chihuahua";
            string ciudad = "Ciudad Juárez";
            string municipio = "Juárez";
            string colonia = "Revolución";
            string codigoPostal = "32000";
            string calle = "Olivo";
            string numeroInterior = "1465";
            string numeroExterior = "2b";

            Assert.DoesNotThrow(() =>
            {
                _sucursal.ActualizarDomicilio(
                   pais,
                   estado,
                   ciudad,
                   municipio,
                   colonia,
                   codigoPostal,
                   calle,
                   numeroInterior,
                   numeroExterior
                   );
            });

        }
    }
}
