using API.IntegrationTests.Common;
using Facturacion.API;
using Facturacion.Domain.Enums;
using FluentValidation;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTests.Controllers.Sucursal
{
    [TestFixture]
    public class GetCfdis : ControllerTestBase
    {
        [Test]
        public async Task GetCfdis_ComandoValido_DebeRegresarSuccess()
        {
            var response = await _authenticatedHttpClient.GetAsync($"/api/sucursales/28295566-3c6b-42c4-850e-f36d5d4faaac/cfdi");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var cfdis = JsonConvert.DeserializeObject<IEnumerable<Facturacion.Application.UseCases.Cfdis.Queries.GetCfdiPorSucursal.CfdiItemVm>>(json);

            Assert.AreEqual(cfdis.Count(), 1);
            var cfdi = cfdis.First();

            Assert.AreEqual(cfdi.Id, Guid.Parse("0ccfba72-efdb-4869-a975-de51cecae97c"));
            Assert.AreEqual(cfdi.Serie, "f");
            Assert.AreEqual(cfdi.Folio, 1);
            Assert.AreEqual(cfdi.FechaEmision, new DateTime(2020, 7, 20, 13, 0, 0));
            Assert.AreEqual(cfdi.RfcCliente, "XAXX010101000");
            Assert.AreEqual(cfdi.RazonSocialCliente, "Cliente SA de CV");
            Assert.AreEqual(cfdi.Total, 1);
        }
    

    [Test]
    public async Task GetCfdis_NoAutenticado_DebeRegresarUnauthorized()
    {
        var client = _factory.GetAnonymousClient();
        var response = await client.GetAsync($"/api/sucursales/28295566-3c6b-42c4-850e-f36d5d4faaac/cfdi");
        Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}
}
