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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace API.IntegrationTests.Controllers.Empresa
{
    [TestFixture]
    public class GetTests : ControllerTestBase
    {
        [Test]
        public async Task GetEmpresas_ComandoValido_DebeRegresarSuccessYDatos()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/empresas/");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Facturacion.Application.UseCases.Empresas.GetEmpresas.EmpresasVm>>(json);

            Assert.AreEqual(result.Count(), 1);
            var empresa = result.First();
            Assert.AreEqual(empresa.Id, Guid.Parse("86904cc6-7838-4beb-85d8-9dad30148b11"));
            Assert.AreEqual(empresa.Rfc, "XAXX010101000");
            Assert.AreEqual(empresa.RazonSocial, "Razón social test");
            Assert.AreEqual(empresa.NombreComercial, "Nombre comercial test");
        }

        [Test]
        public async Task GetEmpresas_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync($"/api/empresas/");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
