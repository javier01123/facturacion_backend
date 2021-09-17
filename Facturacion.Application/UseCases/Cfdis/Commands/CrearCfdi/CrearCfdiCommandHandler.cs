using Facturacion.Application.Common.Context.Extensions;
using Facturacion.Application.Persistence.Context;
using Facturacion.Domain.Aggregates;
using Facturacion.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Facturacion.Application.UseCases.Cfdis.Commands.CrearCfdi
{
    public class CrearCfdiCommandHandler : IRequestHandler<CrearCfdiCommand>
    {
        private readonly FacturacionContext _context;
        public CrearCfdiCommandHandler(FacturacionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(CrearCfdiCommand request, CancellationToken cancellationToken)
        {
            int folio = await _context.GetSiguienteFolioDisponibleAsync(request.SucursalId);

            var cfdi = Cfdi.Create(
                request.Id,
                request.ClienteId,
                request.SucursalId,
                request.FechaEmision,
                request.Serie,
                folio
                );

            cfdi.AsignarTasaIva(request.TasaIva);

            //TODO: this logic should be in the entity
            if (request.Partidas != null)
                foreach (var partida in request.Partidas)
                    cfdi.AgregarPartida(partida.Id, partida.Cantidad, partida.ValorUnitario, partida.Descripcion);

            cfdi.CambiarMetodoDePago(MetodoDePago.PagoEnUnaSolaExhibicion);

            _context.Add(cfdi);
            await _context.SaveChangesAsync();             
            return Unit.Value;
        }
    }
}
