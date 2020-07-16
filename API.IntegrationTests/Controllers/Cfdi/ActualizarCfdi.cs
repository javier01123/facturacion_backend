using API.IntegrationTests.Common;
using Facturacion.Application.UseCases.Cfdis.Commands.ActualizarCfdi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTests.Controllers.Cfdi
{
    [TestFixture]
    public class ActualizarCfdi: ControllerTestBase
    {
        [Test]
        public async Task ActualizarCfdi_DatosValidos_DebeRegresarSuccess()
        {
            var command = new ActualizarCfdiCommand()
            {
                Id = Guid.Parse("0ccfba72-efdb-4869-a975-de51cecae97c"),
                ClienteId = Guid.NewGuid(),
                FechaEmision = DateTime.Now                 
            };

            var content = Utilities.GetRequestContent(command);
            var response = await _authenticatedHttpClient.PutAsync($"/api/cfdi/", content);
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task CrearCfdi_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var command = new ActualizarCfdiCommand();
            var content = Utilities.GetRequestContent(command);
            var response = await client.PutAsync($"/api/cfdi/", content);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
