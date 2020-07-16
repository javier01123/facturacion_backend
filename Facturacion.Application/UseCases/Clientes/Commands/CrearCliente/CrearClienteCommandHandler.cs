
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.UseCases.Clientes.Commands.CrearCliente
{
    public class CrearClienteCommandHandler : IRequestHandler<CrearClienteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteRepository _clienteRepository;

        public CrearClienteCommandHandler(IUnitOfWork unitOfWork, IClienteRepository clienteRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public async Task<Unit> Handle(CrearClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = Cliente.Create(request.Id, request.EmpresaId, request.Rfc, request.RazonSocial);
            _clienteRepository.AddCliente(cliente);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
