using API.IntegrationTests.Common;
using Facturacion.API;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTests.Controllers.Cfdi
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
            var response = await _authenticatedHttpClient.GetAsync($"/api/cfdi/0ccfba72-efdb-4869-a975-de51cecae97c");
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task GetyById_IdNoExistente_DebeRegresarNotFound()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/cfdi/ad936d1f-25df-410e-ace9-9a9e161bf0b2");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public async Task GetById_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync($"/api/cfdi/0ccfba72-efdb-4869-a975-de51cecae97c");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

    }
}
