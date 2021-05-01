
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Application.Common.Exceptions;
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

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmpresaRepository _empresaRepository;

        public ActualizarDatosEmpresaCommandHandler(IUnitOfWork unitOfWork, IEmpresaRepository empresaRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _empresaRepository = empresaRepository ?? throw new ArgumentNullException(nameof(empresaRepository));
        }

        public async Task<Unit> Handle(ActualizarDatosEmpresaCommand request, CancellationToken cancellationToken)
        {
            using (_unitOfWork.StartTransaction())
            {
                var empresa = await _empresaRepository.FindById(request.Id);
                if (empresa == null)
                    throw new NotFoundException(nameof(Empresa), request.Id);
                empresa.ActualizarRazonSocial(request.RazonSocial);
                empresa.ActualizarNombreComercial(request.NombreComercial);
                _empresaRepository.UpdateEmpresa(empresa);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                _unitOfWork.Commit();
            }

            return Unit.Value;
        }

    }
}
