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
    public class GetClientes: ControllerTestBase
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
        public async Task GetClientes_ComandoValido_DebeRegresarSuccess()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/empresas/86904cc6-7838-4beb-85d8-9dad30148b11/clientes");
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task GetClientes_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync($"/api/empresas/86904cc6-7838-4beb-85d8-9dad30148b11/clientes");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
