using API.IntegrationTests.Common;
using Facturacion.API;
using Facturacion.Application.UseCases.Clientes.Commands.CrearCliente;
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

namespace API.IntegrationTests.Controllers.Cliente
{
    [TestFixture]
    public class Create: ControllerTestBase
    {
         

        [Test]
        public async Task CrearCliente_ComandoValido_DebeRegresarSuccess()
        {
            var command = new CrearClienteCommand()
            {
                Id = Guid.NewGuid(),
                EmpresaId = Guid.Parse("86904cc6-7838-4beb-85d8-9dad30148b11"),
                RazonSocial = "Cliente creado del test",
                Rfc = "XBXX010101000"

            };
            var content = Utilities.GetRequestContent(command);
            var response = await _authenticatedHttpClient.PostAsync($"/api/clientes/", content);
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task CrearCliente_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var command = new CrearClienteCommand();
            var content = Utilities.GetRequestContent(command);
            var response = await client.PostAsync($"/api/clientes/", content);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }


    }
}
