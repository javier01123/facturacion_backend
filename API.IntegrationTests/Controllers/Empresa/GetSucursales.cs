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

namespace API.IntegrationTests.Controllers.Sucursal
{
    [TestFixture]
    public class GetSucursales : ControllerTestBase
    {
        [Test]
        public async Task GetSucursales_ComandoValido_DebeRegresarSuccess()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/empresas/86904cc6-7838-4beb-85d8-9dad30148b11/sucursales");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Facturacion.Application.UseCases.Sucursales.Queries.GetSucursales.SucursalDto>>(json);

            Assert.AreEqual(result.Count(), 1);
            var sucursal = result.First();
            Assert.AreEqual(sucursal.Id, Guid.Parse("28295566-3c6b-42c4-850e-f36d5d4faaac"));
            Assert.AreEqual(sucursal.EmpresaId, Guid.Parse("86904cc6-7838-4beb-85d8-9dad30148b11"));
            Assert.AreEqual(sucursal.Nombre, "Sucursal Matriz");
        }

        [Test]
        public async Task GetSucursales_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync($"/api/empresas/86904cc6-7838-4beb-85d8-9dad30148b11/sucursales");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
