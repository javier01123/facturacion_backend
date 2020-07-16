using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Facturacion.Application.UseCases.Clientes.Commands.ActualizarDatosCliente;
using Facturacion.Application.UseCases.Clientes.Commands.CrearCliente;
using Facturacion.Application.UseCases.Clientes.Queries.GetCliente;
using Facturacion.Application.UseCases.Clientes.Queries.GetListaClientes;
using Microsoft.AspNetCore.Mvc;

namespace Facturacion.API.Controllers
{
    [Route("api/clientes")]
    public class ClienteController : BaseController
    {
 

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<ClienteDto>> GetCliente([FromRoute] GetClienteCommand command)
        {
            var clientes = await Mediator.Send(command);
            return Ok(clientes);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> AltaCliente([FromBody] CrearClienteCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult> ActualizarDatos([FromBody] ActualizarDatosClienteCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }


    }
}
