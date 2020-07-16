using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Commands.CrearCfdi
{
   public  class PartidaVm
    {
        public Guid Id { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Importe { get; set; }
        public string Descripcion { get; set; }

    }
}
