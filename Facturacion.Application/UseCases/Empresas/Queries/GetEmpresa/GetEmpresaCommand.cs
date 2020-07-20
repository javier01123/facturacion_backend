using Facturacion.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Empresas.GetEmpresa
{
    public class GetEmpresaCommand : IRequest<EmpresaVm>
    {
        public Guid Id { get; set; }
    }
}
