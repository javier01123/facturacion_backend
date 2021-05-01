
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Contracts.Repositories;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISucursalRepository _sucursalRepository;

        public ActualizarDatosSucursalCommandHandler(IUnitOfWork unitOfWork, ISucursalRepository sucursalRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _sucursalRepository = sucursalRepository ?? throw new ArgumentNullException(nameof(sucursalRepository));
        }

        public async Task<Unit> Handle(ActualizarDatosSucursalCommand request, CancellationToken cancellationToken)
        {
            using (_unitOfWork.StartTransaction())
            {
                var sucursal = await _sucursalRepository.FindById(request.Id);
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

                _sucursalRepository.UpdateSucursal(sucursal);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                _unitOfWork.Commit();
            }
            return Unit.Value;
        }

    }
}
