using API.IntegrationTests.Common;
using Facturacion.API;
using Facturacion.Application.UseCases.Cfdis.Commands.CrearCfdi;
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
    public class CrearCfdi : ControllerTestBase
    {
        [Test]
        public async Task CrearCfdi_DatosValidos_DebeRegresarSuccess()
        {
            var command = new CrearCfdiCommand()
            {
                Id = Guid.NewGuid(),
                ClienteId = Guid.NewGuid(),
                SucursalId = Guid.NewGuid(),
                FechaEmision = DateTime.Now,
                Serie = "F"                
            };

            var content = Utilities.GetRequestContent(command);
            var response = await _authenticatedHttpClient.PostAsync($"/api/cfdi/", content);
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task CrearCfdi_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var command = new CrearCfdiCommand();
            var content = Utilities.GetRequestContent(command);
            var response = await client.PostAsync($"/api/cfdi/", content);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }



    }
}
