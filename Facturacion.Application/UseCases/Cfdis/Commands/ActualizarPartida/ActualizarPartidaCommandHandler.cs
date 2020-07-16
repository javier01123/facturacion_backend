using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Application.Common.Exceptions;
using Facturacion.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Facturacion.Application.UseCases.Cfdis.Commands.ActualizarPartida
{
    public class ActualizarPartidaCommandHandler : IRequestHandler<ActualizarPartidaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICfdiRepository _cfdiRepository;
        public ActualizarPartidaCommandHandler(IUnitOfWork unitOfWork, ICfdiRepository cfdiRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _cfdiRepository = cfdiRepository ?? throw new ArgumentNullException(nameof(cfdiRepository));
        }
        public async Task<Unit> Handle(ActualizarPartidaCommand request, CancellationToken cancellationToken)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var cfdi = await _cfdiRepository.GetById(request.CfdiId);

                if (cfdi == null)
                    throw new NotFoundException(nameof(Cfdi), request.CfdiId);

                cfdi.ModificarPartida(request.Id,request.Cantidad,request.ValorUnitario,request.Descripcion);

                _cfdiRepository.UpdateCfdi(cfdi);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                transactionScope.Complete();
            }

            return Unit.Value;
        }
    }
}
