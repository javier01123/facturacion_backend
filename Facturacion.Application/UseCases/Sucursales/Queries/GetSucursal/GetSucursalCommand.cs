using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Sucursales.Queries.GetSucursal
{
    public class GetSucursalCommand:IRequest<SucursalVm>
    {
        public Guid Id { get; set; }
    }
}
