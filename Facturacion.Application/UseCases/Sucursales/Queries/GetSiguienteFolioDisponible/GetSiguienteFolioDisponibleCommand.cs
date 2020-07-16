using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Sucursales.Queries.GetSiguienteFolioDisponible
{
   public class GetSiguienteFolioDisponibleCommand : IRequest<int>
    {
        public Guid SucursalId { get; set; }
    }
}
