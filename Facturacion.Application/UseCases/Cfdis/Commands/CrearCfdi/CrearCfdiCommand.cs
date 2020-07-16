using Facturacion.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Commands.CrearCfdi
{
    public class CrearCfdiCommand : IRequest
    {
        public PartidaVm[] Partidas { get; set; }
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Guid SucursalId { get; set; }
        public string Serie { get; set; }
        public DateTime FechaEmision { get; set; }
        public int TasaIva { get; set; }
    }
}
