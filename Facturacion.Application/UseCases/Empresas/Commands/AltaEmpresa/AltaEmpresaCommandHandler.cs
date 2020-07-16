
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Application.Common.Exceptions;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ISucursalRepository _sucursalRepository;

        public AltaEmpresaCommandHandler(IUnitOfWork unitOfWork, IEmpresaRepository empresaRepository, ISucursalRepository sucursalRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _empresaRepository = empresaRepository ?? throw new ArgumentNullException(nameof(empresaRepository));
            _sucursalRepository = sucursalRepository ?? throw new ArgumentNullException(nameof(sucursalRepository));
        }

        public async Task<Unit> Handle(AltaEmpresaCommand request, CancellationToken cancellationToken)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var rfcVo = Rfc.For(request.Rfc);
                var empresaExistente = await _empresaRepository.FindByRfc(rfcVo);

                if (empresaExistente != null)
                    throw new RfcEmpresaDuplicadoException(request.Rfc);

                var empresa = Empresa.Create(request.Id, request.Rfc, request.RazonSocial, request.NombreComercial);
                var sucursal = Sucursal.Create(Guid.NewGuid(), empresa.Id, "Matriz");
                _empresaRepository.AddEmpresa(empresa);
                _sucursalRepository.AddSucursal(sucursal);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                transactionScope.Complete();
            }

            return Unit.Value;
        }

    }
}
