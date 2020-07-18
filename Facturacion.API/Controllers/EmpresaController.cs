using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Facturacion.Application.UseCases.Empresas.AltaEmpresa;
using Facturacion.Application.UseCases.Empresas.ActualizarDatosEmpresa;
using Facturacion.Application.UseCases.Empresas.GetEmpresa;
using Facturacion.Application.UseCases.Empresas.GetListaEmpresas;
using Microsoft.AspNetCore.Cors;
using Facturacion.API.auth;
using Microsoft.AspNetCore.Authorization;
using Facturacion.Application.UseCases.Empresas.Queries.IsRfcDisponible;
using Facturacion.Application.UseCases.Sucursales.Queries.GetSucursales;
using Facturacion.Application.UseCases.Clientes.Queries.GetListaClientes;
using HybridModelBinding;
using Facturacion.Application.UseCases.Clientes.Queries.SearchClientes;

namespace Facturacion.API.Controllers
{

    [Route("api/empresas")]
    public class EmpresaController : BaseController
    {
        [Route("")]
        [HttpPost]
        public async Task<ActionResult> AltaEmpresa([FromBody] AltaEmpresaCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult> Put([FromBody] ActualizarDatosEmpresaCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<Application.UseCases.Empresas.GetEmpresa.EmpresaDto>> Get([FromRoute] GetEmpresaCommand command)
        {
            var empresa = await Mediator.Send(command);
            return Ok(empresa);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Application.UseCases.Empresas.GetListaEmpresas.EmpresaDto>>> Get([FromRoute] GetListaEmpresasCommand command)
        {
            var empresas = await Mediator.Send(command);
            return Ok(empresas);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("isRfcDisponible/{Rfc}")]
        public async Task<ActionResult> isRfcDisponible([FromRoute] IsRfcDisponibleCommand command)
        {
            bool estaDisponible = await Mediator.Send(command);
            return Ok(estaDisponible);
        }


        [HttpGet]
        [Route("{EmpresaId}/sucursales")]
        public async Task<ActionResult<IEnumerable<Facturacion.Application.UseCases.Sucursales.Queries.GetSucursales.SucursalDto>>> GetSucursales([FromRoute] GetSucursalesCommand command)
        {
            var sucursales = await Mediator.Send(command);
            return Ok(sucursales);
        }



        [HttpGet]
        [Route("{EmpresaId}/clientes")]
        public async Task<ActionResult<IEnumerable<ClienteItemDto>>> GetClientes([FromRoute] GetClientesCommand command)
        {
            var clientes = await Mediator.Send(command);
            return Ok(clientes);
        }

        [HttpPost]
        [Route("{EmpresaId}/clientes/search")]
        public async Task<ActionResult<IEnumerable<ClienteItemDto>>> SearchClientes([FromHybrid] SearchClientesCommand command)
        {
            var clientes = await Mediator.Send(command);
            return Ok(clientes);
        }

    }
}