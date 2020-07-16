using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facturacion.Application.UseCases.Empresas.AltaEmpresa;
using Microsoft.AspNetCore.Mvc;
using Facturacion.Application.UseCases.Sucursales.Queries.GetSucursal;
using Facturacion.Application.UseCases.Sucursales.Queries.GetSucursales;
using Facturacion.Application.UseCases.Sucursales.ActualizarDatosSucursal;
using Facturacion.Application.UseCases.Cfdis.Queries.GetCfdiPorSucursal;
using Facturacion.Application.UseCases.Sucursales.Queries.GetSiguienteFolioDisponible;

namespace Facturacion.API.Controllers
{
    [Route("api/sucursales")]
    public class SucursalController : BaseController
    {

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<Facturacion.Application.UseCases.Sucursales.Queries.GetSucursal.SucursalDto>> GetSucursal([FromRoute] GetSucursalCommand command)
        {
            var sucursales = await Mediator.Send(command);
            return Ok(sucursales);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> RegistrarNuevaSucursal([FromBody] RegistrarNuevaSucursalCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }


        [HttpPut]
        [Route("")]
        public async Task<ActionResult> ActualizarDatos([FromBody]  ActualizarDatosSucursalCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }


        [HttpGet]
        [Route("{SucursalId}/cfdi")]
        public async Task<ActionResult<IEnumerable<CfdiItemVm>>> GetCfdiPorEmpresa([FromRoute] GetCfdiPorSucursalCommand command)
        {
            var cfdi = await Mediator.Send(command);
            return Ok(cfdi);
        }

        [HttpGet]
        [Route("{SucursalId}/siguiente-folio")]
        public async Task<ActionResult<IEnumerable<CfdiItemVm>>> GetSiguienteFolioDisponible([FromRoute] GetSiguienteFolioDisponibleCommand command)
        {
            var siguienteFolio = await Mediator.Send(command);
            return Ok(siguienteFolio);
        }
    }
}
