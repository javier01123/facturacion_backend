using Facturacion.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Commands.ActualizarCfdi
{
    public class ActualizarCfdiCommand : IRequest
    {      
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime FechaEmision { get; set; }
        public MetodoDePago MetodoDePago { get; set; }

        public PartidaVm[] Partidas { get; set; }
    }
}
