
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Contracts.Repositories;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISucursalRepository _sucursalRepository;

        public RegistrarNuevaSucursalCommandHandler(IUnitOfWork unitOfWork, ISucursalRepository sucursalRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _sucursalRepository = sucursalRepository ?? throw new ArgumentNullException(nameof(sucursalRepository));
        }

        public async Task<Unit> Handle(RegistrarNuevaSucursalCommand request, CancellationToken cancellationToken)
        {
            var sucursal = Sucursal.Create(request.Id, request.EmpresaId, request.Nombre);
            _sucursalRepository.AddSucursal(sucursal);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}
