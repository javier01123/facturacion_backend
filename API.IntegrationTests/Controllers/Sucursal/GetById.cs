using API.IntegrationTests.Common;
using Facturacion.API;
using Facturacion.Application.UseCases.Empresas.ActualizarDatosEmpresa;
using Facturacion.Application.UseCases.Empresas.AltaEmpresa;
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
    public class GetById: ControllerTestBase
    {
        [Test]
        public async Task GetById_IdExistente_DebeRegresarSuccess()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/sucursales/28295566-3c6b-42c4-850e-f36d5d4faaac");
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task GetById_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync($"/api/sucursales/28295566-3c6b-42c4-850e-f36d5d4faaac");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Test]
        public async Task GetById_NoExistente_DebeRegresar404()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/sucursales/63df06d6-48ec-4d24-9ddd-51e91021f0fe");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
