using Facturacion.Domain.Aggregates;
using Facturacion.Domain.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.Aggregates.EmpresaTests
{
    [TestFixture]
    public class Create
    {
        [Test]
        public void CrearEmpresa_DatosValidos_DebeRegresarLaEmpresa()
        {
            //arrange
            var id = Guid.NewGuid();
            var razonSocial = "Razon social demo sa de cv";
            var nombreComercial = "nombre demo";
            var rfc = "XAXX010101000";

            //act
            var empresa = Empresa.Create(id, rfc, razonSocial, nombreComercial);

            //assert
            Assert.IsNotNull(empresa);
            Assert.AreEqual(rfc, empresa.Rfc.Value);
            Assert.AreEqual(id, empresa.Id);
        }


        [Test]
        public void CrearEmpresa_IdVacio_DebeLanzarEx()
        {
            var id = Guid.Empty;
            var razonSocial = "Razon social demo sa de cv";
            var nombreComercial = "nombre demo";
            var rfc = "XAXX010101000";

            Assert.Throws<InvalidParameterException>(() => Empresa.Create(id, rfc, razonSocial, nombreComercial));
        }

        [Test]
        public void CrearEmpresa_RazonSocialVacia_DebeLanzarEx()
        {
            var id = Guid.NewGuid();
            var razonSocial = " ";
            var nombreComercial = "nombre demo";
            var rfc = "XAXX010101000";

            Assert.Throws<InvalidParameterException>(() => Empresa.Create(id, rfc, razonSocial, nombreComercial));
        }


        [Test]
        public void CrearEmpresa_NombreComercialVacio_DebeLanzarEx()
        {
            var id = Guid.Empty;
            var razonSocial = "Razon social demo sa de cv";
            var nombreComercial = "";
            var rfc = "XAXX010101000";

            Assert.Throws<InvalidParameterException>(() => Empresa.Create(id, rfc, razonSocial, nombreComercial));
        }
    }
}
