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

namespace API.IntegrationTests.Controllers.Sucursal
{
    [TestFixture]
    public class GetById : ControllerTestBase
    {
        [Test]
        public async Task GetById_IdExistente_DebeRegresarSuccessYDatos()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/sucursales/28295566-3c6b-42c4-850e-f36d5d4faaac");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var sucursal = JsonConvert.DeserializeObject<Facturacion.Application.UseCases.Sucursales.Queries.GetSucursal.SucursalVm>(json);
            Assert.AreEqual(sucursal.Id, Guid.Parse("28295566-3c6b-42c4-850e-f36d5d4faaac"));
            Assert.AreEqual(sucursal.EmpresaId, Guid.Parse("86904cc6-7838-4beb-85d8-9dad30148b11"));
            Assert.AreEqual(sucursal.Nombre, "Sucursal Matriz");
            Assert.AreEqual(sucursal.Pais, "México");
            Assert.AreEqual(sucursal.Estado, "Chihuahua");
            Assert.AreEqual(sucursal.Ciudad, "Ciudad Juárez");
            Assert.AreEqual(sucursal.Municipio, "Juárez");
            Assert.AreEqual(sucursal.Colonia, "Revolución");
            Assert.AreEqual(sucursal.Calle, "Flores");
            Assert.AreEqual(sucursal.CodigoPostal, "32000");
            Assert.AreEqual(sucursal.NumeroInterior, "1");
            Assert.AreEqual(sucursal.NumeroExterior, "2");
        }

        [Test]
        public async Task GetById_NoAutenticado_DebeRegresarUnauthorized()
        {
            var client = _factory.GetAnonymousClient();
            var response = await client.GetAsync($"/api/sucursales/28295566-3c6b-42c4-850e-f36d5d4faaac");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Test]
        public async Task GetById_NoExistente_DebeRegresar404()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/sucursales/63df06d6-48ec-4d24-9ddd-51e91021f0fe");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
