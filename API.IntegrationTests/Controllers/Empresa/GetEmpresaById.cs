using API.IntegrationTests.Common;
using Facturacion.API;
using Facturacion.Application.UseCases.Empresas.ActualizarDatosEmpresa;
using Facturacion.Application.UseCases.Empresas.AltaEmpresa;
using Facturacion.Application.UseCases.Usuarios.Queries.ValidarCredenciales;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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
    public class GetEmpresaById : ControllerTestBase
    {
        [Test]
        public async Task GetById_ComandoValido_DebeRegresarSuccessYDatos()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/empresas/86904cc6-7838-4beb-85d8-9dad30148b11");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Facturacion.Application.UseCases.Empresas.GetEmpresa.EmpresaVm>(json);

            Assert.AreEqual(result.Id, Guid.Parse("86904cc6-7838-4beb-85d8-9dad30148b11"));
            Assert.AreEqual(result.Rfc, "XAXX010101000");
            Assert.AreEqual(result.RazonSocial, "Razón social test");
            Assert.AreEqual(result.NombreComercial, "Nombre comercial test");
        }

        [Test]
        public async Task GetById_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync($"/api/empresas/86904cc6-7838-4beb-85d8-9dad30148b11");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Test]
        public async Task GetById_IdNoExistente_DebeRegresar404()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/empresas/dd0c7bb8-1159-4f46-8b44-1b7de0786983");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }


    }
}
