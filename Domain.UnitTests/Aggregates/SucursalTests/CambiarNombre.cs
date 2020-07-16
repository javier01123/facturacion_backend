using Facturacion.Domain.Aggregates;
using Facturacion.Domain.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.Aggregates.SucursalTests
{
    [TestFixture]
    public class CambiarNombre
    {
        [Test]
        public void CambiarNombre_NombreValido_noDebeLanzarEx()
        {
            var id = Guid.NewGuid();
            var empresaId = Guid.NewGuid();
            var nombre = "Sucursal prueba";
            var sucursal = Sucursal.Create(id, empresaId, nombre);
            var nuevoNombre = "sucursal nuevo nombre";

            Assert.DoesNotThrow(() => sucursal.CambiarNombre(nuevoNombre));
        }

        [Test]
        public void CambiarNombre_NuevoNombreVacio_DebeLanzarEx()
        {
            var id = Guid.NewGuid();
            var empresaId = Guid.NewGuid();
            var nombre = "Sucursal prueba";
            var sucursal = Sucursal.Create(id, empresaId, nombre);
            var nuevoNombre = "";

            Assert.Throws<GenericDomainException>(() =>
            sucursal.CambiarNombre(nuevoNombre));
        }

    }
}
