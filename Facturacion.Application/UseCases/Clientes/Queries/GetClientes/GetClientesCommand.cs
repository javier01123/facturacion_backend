using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Clientes.Queries.GetListaClientes
{
    public class GetClientesCommand:IRequest<IEnumerable<ClienteItemDto>>
    {
        public Guid EmpresaId { get; set; }
    }
}
