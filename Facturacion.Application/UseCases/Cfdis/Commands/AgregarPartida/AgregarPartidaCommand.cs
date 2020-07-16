using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Commands.AgregarPartida
{
    public class AgregarPartidaCommand:IRequest
    {
        public Guid CfdiId { get; set; }
        public Guid Id { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Descripcion { get; set; }
    }
}
