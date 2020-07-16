using API.IntegrationTests.Common;
using Facturacion.API;
using Facturacion.Application.UseCases.Empresas.ActualizarDatosEmpresa;
using Facturacion.Application.UseCases.Empresas.AltaEmpresa;
using Facturacion.Application.UseCases.Sucursales.ActualizarDatosSucursal;
using Facturacion.Application.UseCases.Usuarios.Queries.ValidarCredenciales;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace API.IntegrationTests.Controllers.Sucursal
{
    [TestFixture]
    public class Update : ControllerTestBase
    {

        [Test]
        public async Task ActualizarSucursal_ComandoValido_DebeRegresarSuccess()
        {
            var command = new ActualizarDatosSucursalCommand()
            {
                Id = Guid.Parse("28295566-3c6b-42c4-850e-f36d5d4faaac"),
                Nombre = "Sucursal Jalisco",
                Calle = "Rosa",
                NumeroExterior = "123",
                NumeroInterior = "434",
                Ciudad = "Cuahutemoc",
                CodigoPostal = "31322",
                Colonia = "Morelos",
                Estado = "Jalisco",
                Municipio = "Jalisco",
                Pais = "México"

            };
            var content = Utilities.GetRequestContent(command);
            var response = await _authenticatedHttpClient.PutAsync($"/api/sucursales/", content);
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task ActualizarSucursal_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var command = new ActualizarDatosSucursalCommand();
            var content = Utilities.GetRequestContent(command);
            var response = await client.PutAsync($"/api/sucursales/", content);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

    }
}
