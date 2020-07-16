using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Queries.GetCfdiPorSucursal
{
    public class CfdiItemVm
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public string Serie { get; set; }
        public int Folio { get; set; }
        public DateTime FechaEmision { get; set; }
        public string RfcCliente { get; set; }
        public string RazonSocialCliente { get; set; }
        public decimal Total { get; set; }
    }
}
