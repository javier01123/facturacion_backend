using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Sucursales.Queries.GetSucursales
{
    public class GetSucursalesCommand:IRequest<IEnumerable<SucursalDto>>
    {
        public Guid EmpresaId { get; set; }
    }
}
