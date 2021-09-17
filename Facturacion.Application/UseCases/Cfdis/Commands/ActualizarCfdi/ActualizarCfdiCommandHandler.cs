using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Application.Common.Exceptions;
using Facturacion.Application.Persistence.Context;
using Facturacion.Domain.Aggregates;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Facturacion.Application.UseCases.Cfdis.Commands.ActualizarCfdi
{
    public class ActualizarCfdiCommandHandler : IRequestHandler<ActualizarCfdiCommand>
    {
        private readonly FacturacionContext _context;

        public ActualizarCfdiCommandHandler(FacturacionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(ActualizarCfdiCommand request, CancellationToken cancellationToken)
        {
            var cfdi = await _context.Cfdi.FindAsync(request.Id);
            if (cfdi == null)
                throw new NotFoundException(nameof(Cfdi), request.Id);

            cfdi.CambiarCliente(request.ClienteId);
            cfdi.CambiarFechaEmision(request.FechaEmision);
            cfdi.CambiarMetodoDePago(request.MetodoDePago);
            cfdi.AsignarTasaIva(request.TasaIva);

            //TODO:the entity should be responsible of this logic
            cfdi.EliminarPartidas();
            if (request.Partidas != null)
                foreach (var partida in request.Partidas)
                    cfdi.AgregarPartida(partida.Id, partida.Cantidad, partida.ValorUnitario, partida.Descripcion);
            ///

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
