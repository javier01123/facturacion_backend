using API.IntegrationTests.Common;
using Facturacion.Application.UseCases.Cfdis.Commands.AgregarPartida;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTests.Controllers.Cfdi
{
    [TestFixture]
    public class AgregarPartida : ControllerTestBase
    {
        [Test]
        public async Task AgregarPartida_DatosValidos_DebeRegresarSuccess()
        {
            var cfdiId =  Guid.Parse("0ccfba72-efdb-4869-a975-de51cecae97c");

            var command = new AgregarPartidaCommand()
            {               
                Id = Guid.NewGuid(),
                Cantidad = 1,
                ValorUnitario = 20.55m,
                Descripcion = "partida número 1"
            };

            var content = Utilities.GetRequestContent(command);
            var response = await _authenticatedHttpClient.PostAsync($"/api/cfdi/{cfdiId}/partidas", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
