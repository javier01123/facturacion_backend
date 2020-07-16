using Facturacion.Domain.Aggregates;
using Facturacion.Domain.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.Aggregates.EmpresaTests
{
    [TestFixture]
    public class ActualizarRazonSocial
    {
        private Empresa _empresa;

        [SetUp]
        public void SetUp()
        {
            var id = Guid.NewGuid();
            var razonSocial = "Razon Social";
            var nombreComercial = "Nombre Comercial";
            var rfc = "XAXX010101000";

            _empresa = Empresa.Create(id, rfc, razonSocial, nombreComercial);
        }

        [Test]
        public void CambiarNombre_RazonSocialValida_NoDebeLanzarEx()
        {
            var nuevaRazonSocial = "nueva razon social";
            Assert.DoesNotThrow(() => _empresa.ActualizarRazonSocial(nuevaRazonSocial));
        }

        [Test]
        public void CambiarNombre_NombreComercialVacio_DebeLanzarEx()
        {
            var nuevoNombreComercial = "";
            Assert.Throws<GenericDomainException>(() => _empresa.ActualizarNombreComercial(nuevoNombreComercial));
        }
    }
}
