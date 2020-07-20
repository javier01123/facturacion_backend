using Facturacion.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Empresas.GetEmpresas
{
    public class GetEmpresasCommand : IRequest<IEnumerable<EmpresasVm>>
    {
    }
}
