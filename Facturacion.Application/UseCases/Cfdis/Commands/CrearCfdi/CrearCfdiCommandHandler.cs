using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Domain.Aggregates;
using Facturacion.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Facturacion.Application.UseCases.Cfdis.Commands.CrearCfdi
{
    public class CrearCfdiCommandHandler : IRequestHandler<CrearCfdiCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICfdiRepository _cfdiRepository;
        private readonly ISucursalRepository _sucursalRepository;

        public CrearCfdiCommandHandler(IUnitOfWork unitOfWork, ICfdiRepository cfdiRepository, ISucursalRepository sucursalRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _cfdiRepository = cfdiRepository ?? throw new ArgumentNullException(nameof(cfdiRepository));
            _sucursalRepository = sucursalRepository ?? throw new ArgumentNullException(nameof(sucursalRepository));
        }

        public async Task<Unit> Handle(CrearCfdiCommand request, CancellationToken cancellationToken)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                int folio = await _sucursalRepository.GetSiguienteFolioDisponible(request.SucursalId);

                var cfdi = Cfdi.Create(
                    request.Id,
                    request.ClienteId,
                    request.SucursalId,
                    request.FechaEmision,
                    request.Serie,
                    folio
                    );

                cfdi.AsignarTasaIva(request.TasaIva);

                if (request.Partidas != null)
                    foreach (var partida in request.Partidas)
                        cfdi.AgregarPartida(partida.Id, partida.Cantidad, partida.ValorUnitario, partida.Descripcion);

                cfdi.CambiarMetodoDePago(MetodoDePago.PagoEnUnaSolaExhibicion);

                await _cfdiRepository.AddCfdi(cfdi);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                transactionScope.Complete();
            }

            return Unit.Value;
        }
    }
}
