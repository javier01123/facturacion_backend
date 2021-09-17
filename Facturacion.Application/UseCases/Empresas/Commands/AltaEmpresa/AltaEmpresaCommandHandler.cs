
using Facturacion.Application.Common.Context.Extensions;
using Facturacion.Application.Common.Exceptions;
using Facturacion.Application.Persistence.Context;
using Facturacion.Domain.Aggregates;
using Facturacion.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Facturacion.Application.UseCases.Empresas.AltaEmpresa
{
    public class AltaEmpresaCommandHandler : IRequestHandler<AltaEmpresaCommand>
    {
        private readonly FacturacionContext _context;
        
        public AltaEmpresaCommandHandler(FacturacionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(AltaEmpresaCommand request, CancellationToken cancellationToken)
        {  
            //TODO: does a transaction start automatically for the rfc check? i dont think so.
            var rfcVo = Rfc.For(request.Rfc);
            if (await _context.Empresa.IsRfcTaken(rfcVo))
                throw new RfcEmpresaDuplicadoException(rfcVo.Value);
            var empresa = Empresa.Create(request.Id, request.Rfc, request.RazonSocial, request.NombreComercial);
            var sucursal = Sucursal.Create(Guid.NewGuid(), empresa.Id, "Matriz");
            _context.Add(empresa);
            _context.Add(sucursal);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }


    }
}
