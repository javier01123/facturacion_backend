using Facturacion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Queries.GetCfdi
{
    public class CfdiVm
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Serie { get; set; }
        public int Folio { get; set; }
        public MetodoDePago MetodoDePago { get; set; }
        public string RfcCliente { get; set; }
        public string RazonSocialCliente { get; set; }
        public string Sucursal { get; set; }
        public decimal Total { get; set; }


        public List<PartidaVm> Partidas { get; set; }

    }
}
