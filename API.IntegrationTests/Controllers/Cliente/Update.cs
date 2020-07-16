using API.IntegrationTests.Common;
using Facturacion.API;
using Facturacion.Application.UseCases.Clientes.Commands.ActualizarDatosCliente;
using Facturacion.Application.UseCases.Empresas.ActualizarDatosEmpresa;
using Facturacion.Application.UseCases.Empresas.AltaEmpresa;
using Facturacion.Application.UseCases.Sucursales.ActualizarDatosSucursal;
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
    public class Update: ControllerTestBase
    {
        

        [Test]
        public async Task ActualizarCliente_ComandoValido_DebeRegresarSuccess()
        {
            var command = new ActualizarDatosClienteCommand()
            {
                Id = Guid.Parse("c58db24a-37cd-4a43-a9a1-e7247c79323d"),
                RazonSocial = "Razon social cliente actualizada"
            };
            var content = Utilities.GetRequestContent(command);
            var response = await _authenticatedHttpClient.PutAsync($"/api/clientes/", content);
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task ActualizarCliente_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var command = new ActualizarDatosClienteCommand();
            var content = Utilities.GetRequestContent(command);
            var response = await client.PutAsync($"/api/clientes/", content);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

    }
}
