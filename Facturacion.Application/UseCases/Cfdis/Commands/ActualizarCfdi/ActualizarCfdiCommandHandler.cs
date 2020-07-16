using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Application.Common.Exceptions;
using Facturacion.Domain.Aggregates;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Facturacion.Application.UseCases.Cfdis.Commands.ActualizarCfdi
{
    public class ActualizarCfdiCommandHandler : IRequestHandler<ActualizarCfdiCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICfdiRepository _cfdiRepository;
        public ActualizarCfdiCommandHandler(IUnitOfWork unitOfWork, ICfdiRepository cfdiRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _cfdiRepository = cfdiRepository ?? throw new ArgumentNullException(nameof(cfdiRepository));
        }
        public async Task<Unit> Handle(ActualizarCfdiCommand request, CancellationToken cancellationToken)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var cfdi = await _cfdiRepository.GetById(request.Id);

                if (cfdi == null)
                    throw new NotFoundException(nameof(Cfdi), request.Id);
                
                cfdi.CambiarCliente(request.ClienteId);
                cfdi.CambiarFechaEmision(request.FechaEmision);
                cfdi.CambiarMetodoDePago(request.MetodoDePago);
            
                cfdi.EliminarPartidas();

                if (request.Partidas != null)
                    foreach (var partida in request.Partidas)
                        cfdi.AgregarPartida(partida.Id, partida.Cantidad, partida.ValorUnitario, partida.Descripcion);

                _cfdiRepository.UpdateCfdi(cfdi);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                transactionScope.Complete();
            }

            return Unit.Value;
        }
    }
}
