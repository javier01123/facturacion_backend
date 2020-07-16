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

namespace API.IntegrationTests.Controllers.Empresa
{
    [TestFixture]
    public class AltaEmpresa: ControllerTestBase
    {
  
        [Test]
        public async Task AltaEmpresa_ComandoValido_DebeRegresarSuccess()
        {
            var command = new AltaEmpresaCommand()
            {
                Id = Guid.NewGuid(),
                RazonSocial = "Razon Social Test",
                NombreComercial = "Nombre Comercial Test",
                Rfc = "XCXX010101000"
            };
            var content = Utilities.GetRequestContent(command);
            var response = await _authenticatedHttpClient.PostAsync($"/api/empresas/", content);
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task AltaEmpresa_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var command = new AltaEmpresaCommand();
            var content = Utilities.GetRequestContent(command);
            var response = await client.PostAsync($"/api/empresas/", content);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        
    }
}
