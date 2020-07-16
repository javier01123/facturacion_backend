using Facturacion.Domain.Aggregates;
using Facturacion.Domain.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitTests.Aggregates.EmpresaTests
{
    public class CorregirRfc
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
        public void CorregirRfc_FormatoValido_DebeActualizarlaPropiedad()
        {
            var nuevoRfc = "XAXX010101000";
            _empresa.CorregirRfc(nuevoRfc);
            Assert.AreEqual(nuevoRfc, _empresa.Rfc.Value);
        }

        [Test]
        public void CorregirRfc_FormatoInvalido_DebeLanzarFormatoInvalidoRfcEx()
        {
            var nuevoRfc = "XAXX010101";
            Assert.Throws<RfcFormatoInvalidoException>(() => _empresa.CorregirRfc(nuevoRfc));
        }
    }
}
