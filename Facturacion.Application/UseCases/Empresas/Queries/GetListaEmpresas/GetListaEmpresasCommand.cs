using Facturacion.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Empresas.GetListaEmpresas
{
    public class GetListaEmpresasCommand : IRequest<IEnumerable<EmpresaDto>>
    {
    }
}
