
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

namespace Facturacion.Application.UseCases.Sucursales.ActualizarDatosSucursal
{

    public class ActualizarDatosSucursalCommandHandler : IRequestHandler<ActualizarDatosSucursalCommand>
    {
        private readonly FacturacionContext _context;

        public ActualizarDatosSucursalCommandHandler(FacturacionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(ActualizarDatosSucursalCommand request, CancellationToken cancellationToken)
        {
            var sucursal = await _context.Sucursal.FindAsync(request.Id);

            sucursal.CambiarNombre(request.Nombre);
            sucursal.ActualizarDomicilio(
            request.Pais,
            request.Estado,
            request.Ciudad,
            request.Municipio,
            request.Colonia,
            request.CodigoPostal,
            request.Calle,
            request.NumeroInterior,
            request.NumeroExterior
            );

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}
