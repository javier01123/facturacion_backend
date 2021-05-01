
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
        private AltaEmpresaCommand _request;

        public AltaEmpresaCommandHandler(IUnitOfWork unitOfWork, IEmpresaRepository empresaRepository, ISucursalRepository sucursalRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _empresaRepository = empresaRepository ?? throw new ArgumentNullException(nameof(empresaRepository));
            _sucursalRepository = sucursalRepository ?? throw new ArgumentNullException(nameof(sucursalRepository));
        }

        public async Task<Unit> Handle(AltaEmpresaCommand request, CancellationToken cancellationToken)
        {
            _request = request;

            using (_unitOfWork.StartTransaction())
            {
                var rfcVo = Rfc.For(_request.Rfc);
                await VerifyRfcNotDuplicated(rfcVo);
                var empresa = Empresa.Create(_request.Id, _request.Rfc, _request.RazonSocial, _request.NombreComercial);
                var sucursal = Sucursal.Create(Guid.NewGuid(), empresa.Id, "Matriz");
                _empresaRepository.AddEmpresa(empresa);
                _sucursalRepository.AddSucursal(sucursal);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                _unitOfWork.Commit();
            }
            return Unit.Value;
        }

        private async Task VerifyRfcNotDuplicated(Rfc rfcVo)
        {
            var empresaExistente = await _empresaRepository.FindByRfc(rfcVo);
            if (empresaExistente != null)
                throw new RfcEmpresaDuplicadoException(_request.Rfc);
        }
    }
}
