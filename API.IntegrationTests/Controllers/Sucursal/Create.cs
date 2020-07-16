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

namespace API.IntegrationTests.Controllers.Sucursal
{
    [TestFixture]
    public class Create: ControllerTestBase
    {
        [Test]
        public async Task RegistrarSucursal_ComandoValido_DebeRegresarSuccess()
        {
            var command = new RegistrarNuevaSucursalCommand()
            {
                Id = Guid.NewGuid(),
                EmpresaId = Guid.Parse("86904cc6-7838-4beb-85d8-9dad30148b11"),
                Nombre = "Nueva Sucursal",
                Calle = "Revolución",
                NumeroInterior = "111",
                NumeroExterior = "222",
                Colonia = "Independencia",
                Municipio = "Juárez",
                Ciudad = "Ciudad Juárez",
                Estado = "Chihuahua",
                Pais = "México",
            };
            var content = Utilities.GetRequestContent(command);
            var response = await _authenticatedHttpClient.PostAsync($"/api/sucursales/", content);
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task RegistrarSucursal_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var command = new RegistrarNuevaSucursalCommand();
            var content = Utilities.GetRequestContent(command);
            var response = await client.PostAsync($"/api/sucursales/", content);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }


    }
}
