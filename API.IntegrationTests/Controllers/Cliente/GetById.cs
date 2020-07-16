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

namespace API.IntegrationTests.Controllers.Cliente
{
    [TestFixture]
    public class GetById: ControllerTestBase
    {
        private CustomWebApplicationFactory<Startup> _factory;
        private HttpClient _authenticatedHttpClient;

        [SetUp]
        public void SetUp()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
            _authenticatedHttpClient = _factory.GetAuthenticatedClient();
        }

        [Test]
        public async Task GetById_IdExistente_DebeRegresarSuccess()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/clientes/c58db24a-37cd-4a43-a9a1-e7247c79323d");
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task GetById_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync($"/api/clientes/c58db24a-37cd-4a43-a9a1-e7247c79323d");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Test]
        public async Task GetById_NoExistente_DebeRegresar404()
        {
            var notExitingId = "449eb3ea-8044-4571-ab08-cac4940dbbd0";
            var response = await _authenticatedHttpClient.GetAsync($"/api/clientes/{notExitingId}");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
