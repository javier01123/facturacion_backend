using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Clientes.Queries.SearchClientes
{
    public class SearchClientesCommand : IRequest<IEnumerable<ClienteVm>>
    {
        public Guid EmpresaId { get; set; }
        public string SearchTerm { get; set; }
    }
}
