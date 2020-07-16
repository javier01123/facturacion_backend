using API.IntegrationTests.Common;
using Facturacion.API;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTests.Controllers.Sucursal
{
    [TestFixture]
    public class GetCfdis: ControllerTestBase
    {


        [Test]
        public async Task GetCfdis_ComandoValido_DebeRegresarSuccess()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/sucursales/28295566-3c6b-42c4-850e-f36d5d4faaac/cfdi");
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task GetCfdis_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync($"/api/sucursales/28295566-3c6b-42c4-850e-f36d5d4faaac/cfdi");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
