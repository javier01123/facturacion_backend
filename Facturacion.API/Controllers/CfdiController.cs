using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Facturacion.Application.UseCases.Cfdis.Commands.ActualizarCfdi;
using Facturacion.Application.UseCases.Cfdis.Commands.CrearCfdi;
using Facturacion.Application.UseCases.Cfdis.Queries.GetCfdi;
using HybridModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Facturacion.API.Controllers
{
    [Route("api/cfdi")]
    public class CfdiController : BaseController
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Crear([FromBody] CrearCfdiCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult> GetById([FromRoute] GetCfdiCommand command)
        {
            var cfdi = await Mediator.Send(command);
            return Ok(cfdi);
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult> ActualizarCfdi([FromBody] ActualizarCfdiCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }


    }
}