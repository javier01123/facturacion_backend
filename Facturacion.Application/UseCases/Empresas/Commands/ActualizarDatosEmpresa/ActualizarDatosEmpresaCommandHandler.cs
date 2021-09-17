
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Application.Common.Exceptions;
using Facturacion.Application.Persistence.Context;
using Facturacion.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Facturacion.Application.UseCases.Empresas.ActualizarDatosEmpresa
{

    public class ActualizarDatosEmpresaCommandHandler : IRequestHandler<ActualizarDatosEmpresaCommand>
    {
        private readonly FacturacionContext _context;

        public ActualizarDatosEmpresaCommandHandler(FacturacionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(ActualizarDatosEmpresaCommand request, CancellationToken cancellationToken)
        {
            var empresa = await _context.Empresa.FindAsync(request.Id);
            if (empresa == null)
                throw new NotFoundException(nameof(Empresa), request.Id);
            empresa.ActualizarRazonSocial(request.RazonSocial);
            empresa.ActualizarNombreComercial(request.NombreComercial); 
            await _context.SaveChangesAsync(cancellationToken);      
            return Unit.Value;
        }

    }
}
