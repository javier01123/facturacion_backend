using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Commands.EliminarPartida
{
    public class EliminarPartidaCommand:IRequest
    {
        public Guid CfdiId { get; set; }
        public Guid PartidaId { get; set; }
    }
}
