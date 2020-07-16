using Facturacion.Application.UseCases.Cfdis.Queries.GetCfdi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Queries.GetCfdi
{
   public class GetCfdiCommand:IRequest<CfdiVm>
    {
        public Guid Id { get; set; }
    }
}
