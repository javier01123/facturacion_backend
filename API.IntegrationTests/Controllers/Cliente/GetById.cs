using API.IntegrationTests.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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
        [Test]
        public async Task GetById_IdExistente_DebeRegresarSuccessYDatos()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/clientes/c58db24a-37cd-4a43-a9a1-e7247c79323d");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Facturacion.Application.UseCases.Clientes.Queries.GetCliente.ClienteVm>(json);

            Assert.AreEqual(result.Id, Guid.Parse("c58db24a-37cd-4a43-a9a1-e7247c79323d"));
            Assert.AreEqual(result.Rfc, "XAXX010101000");
            Assert.AreEqual(result.RazonSocial, "Cliente SA de CV");
            Assert.AreEqual(result.EmpresaId, Guid.Parse("86904cc6-7838-4beb-85d8-9dad30148b11"));
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
