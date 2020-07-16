using API.IntegrationTests.Common;
using Facturacion.API;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTests.Controllers.Empresa
{
    [TestFixture]
    public class GetCfdis: ControllerTestBase
    {


        [Test]
        public async Task GetCfdis_ComandoValido_DebeRegresarSuccess()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/empresas/86904cc6-7838-4beb-85d8-9dad30148b11/cfdi");
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task GetSucursales_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync($"/api/empresas/86904cc6-7838-4beb-85d8-9dad30148b11/cfdi");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
