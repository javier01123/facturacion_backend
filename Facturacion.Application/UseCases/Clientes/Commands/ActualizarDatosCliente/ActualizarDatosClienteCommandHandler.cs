
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

namespace Facturacion.Application.UseCases.Clientes.Commands.ActualizarDatosCliente
{
    public class ActualizarDatosClienteCommandHandler : IRequestHandler<ActualizarDatosClienteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteRepository _clienteRepository;

        public ActualizarDatosClienteCommandHandler(IUnitOfWork unitOfWork, IClienteRepository clienteRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public async Task<Unit> Handle(ActualizarDatosClienteCommand request, CancellationToken cancellationToken)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var cliente = await _clienteRepository.FindById(request.Id);
                cliente.CambiarRazonSocial(request.RazonSocial);
                _clienteRepository.UpdateCliente(cliente);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                transactionScope.Complete();
            }
            return Unit.Value;
        }
    }
}
