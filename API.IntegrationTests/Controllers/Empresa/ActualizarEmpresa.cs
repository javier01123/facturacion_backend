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
    public class ActualizarEmpresa: ControllerTestBase
    {
        

        [Test]
        public async Task ActualizarEmpresa_ComandoValido_DebeRegresarSuccess()
        {
            var command = new ActualizarDatosEmpresaCommand()
            {
                Id = Guid.Parse("86904cc6-7838-4beb-85d8-9dad30148b11"),
                RazonSocial = "Razón social Actualizada",
                NombreComercial = "Nombre comercial actualizada",
            };
            var content = Utilities.GetRequestContent(command);
            var response = await _authenticatedHttpClient.PutAsync($"/api/empresas/", content);
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task ActualizarEmpresa_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var command = new ActualizarDatosEmpresaCommand();
            var content = Utilities.GetRequestContent(command);
            var response = await client.PutAsync($"/api/empresas/", content);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

    }
}
