using Facturacion.Application.Persistence.Context;
using Facturacion.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.UseCases.Clientes.Commands.CrearCliente
{
    public class CrearClienteCommandHandler : IRequestHandler<CrearClienteCommand>
    {
        private readonly FacturacionContext _context;

        public CrearClienteCommandHandler(FacturacionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(CrearClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = Cliente.Create(request.Id, request.EmpresaId, request.Rfc, request.RazonSocial);
            _context.Add(cliente);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
