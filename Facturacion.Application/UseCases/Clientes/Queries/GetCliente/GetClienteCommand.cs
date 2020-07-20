using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Clientes.Queries.GetCliente
{
    public class GetClienteCommand : IRequest<ClienteVm>
    {
        public Guid Id { get; set; }
    }
}
