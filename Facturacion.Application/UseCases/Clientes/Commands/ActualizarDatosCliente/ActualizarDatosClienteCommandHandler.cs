
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Application.Persistence.Context;
using Facturacion.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Facturacion.Application.UseCases.Clientes.Commands.ActualizarDatosCliente
{
    public class ActualizarDatosClienteCommandHandler : IRequestHandler<ActualizarDatosClienteCommand>
    {
        private readonly FacturacionContext _context;

        public ActualizarDatosClienteCommandHandler(FacturacionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(ActualizarDatosClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _context.Cliente.FindAsync(request.Id);
            cliente.CambiarRazonSocial(request.RazonSocial);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
