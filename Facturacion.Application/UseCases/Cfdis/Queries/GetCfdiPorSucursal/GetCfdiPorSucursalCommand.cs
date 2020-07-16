using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Queries.GetCfdiPorSucursal
{
    public class GetCfdiPorSucursalCommand:IRequest<IEnumerable<CfdiItemVm>>
    {
        public Guid SucursalId { get; set; }
    }
}
