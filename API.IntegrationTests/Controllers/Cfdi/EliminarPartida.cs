using API.IntegrationTests.Common;
using Facturacion.Application.UseCases.Cfdis.Commands.EliminarPartida;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTests.Controllers.Cfdi
{
    [TestFixture]
    public class EliminarPartida : ControllerTestBase
    {

        [Test]
        public async Task EliminarPartida_IdsExistentes_DebeRegresarSuccess()
        {
            var cfdiId = Guid.Parse("0ccfba72-efdb-4869-a975-de51cecae97c");
            var partidaId = Guid.Parse("74f1da12-c234-476c-a574-3a80d7648595");
            var response = await _authenticatedHttpClient.DeleteAsync($"/api/cfdi/{cfdiId}/partidas/{partidaId}");
            response.EnsureSuccessStatusCode();
        }


    }
}
