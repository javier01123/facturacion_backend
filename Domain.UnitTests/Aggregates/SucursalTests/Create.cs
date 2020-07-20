using Facturacion.Domain.Aggregates;
using Facturacion.Domain.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.Aggregates.SucursalTests
{
    [TestFixture]
    public class Create
    {

        [Test]
        public void Create_datosValidos_instanciaDebeTenerMismosDatos()
        {
            var id = Guid.NewGuid();
            var empresaId = Guid.NewGuid();
            var nombre = "Sucursal prueba";
            var sucursal = Sucursal.Create(id, empresaId, nombre);

            Assert.IsNotNull(sucursal);
            Assert.AreEqual(id, sucursal.Id);
            Assert.AreEqual(empresaId, sucursal.EmpresaId);
        }

        [Test]
        public void Create_EmpresaIdVacio_DebeLanzarEx()
        {
            var id = Guid.NewGuid();
            var empresaId = Guid.Empty;
            var nombre = "Sucursal prueba";

            Assert.Throws<InvalidParameterException>(() => Sucursal.Create(id, empresaId, nombre));
        }

        [Test]
        public void Create_NombreVacio_DebeLanzarEx()
        {
            var id = Guid.NewGuid();
            var empresaId = Guid.NewGuid();
            var nombre = "";

            Assert.Throws<InvalidParameterException>(() => Sucursal.Create(id, empresaId, nombre));
        }

    }
}
