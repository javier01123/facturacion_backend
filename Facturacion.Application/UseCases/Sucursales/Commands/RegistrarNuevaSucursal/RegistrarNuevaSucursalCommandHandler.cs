
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Application.Persistence.Context;
using Facturacion.Domain.Aggregates;
using Facturacion.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.UseCases.Empresas.AltaEmpresa
{
    public class RegistrarNuevaSucursalCommandHandler : IRequestHandler<RegistrarNuevaSucursalCommand>
    {
        private readonly FacturacionContext _context;

        public RegistrarNuevaSucursalCommandHandler(FacturacionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(RegistrarNuevaSucursalCommand request, CancellationToken cancellationToken)
        {
            var sucursal = Sucursal.Create(request.Id, request.EmpresaId, request.Nombre);
            _context.Add(sucursal);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}
