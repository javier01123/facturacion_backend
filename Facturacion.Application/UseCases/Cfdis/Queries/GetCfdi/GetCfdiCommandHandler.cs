using Dapper;
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Exceptions;
using Facturacion.Application.Common.Extensions;
using Facturacion.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.UseCases.Cfdis.Queries.GetCfdi
{
    public class GetCfdiCommandHandler : IRequestHandler<GetCfdiCommand, CfdiVm>
    {
        private ISqlConnectionFactory _sqlConnectionFactory;
        public GetCfdiCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
        }
        public async Task<CfdiVm> Handle(GetCfdiCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            var sqlCfdi = @"
                        SELECT
                        c.[Id],
                        c.[Serie],
                        c.[Folio],
                        c.[MetodoDePago],
                        c.[FechaEmision],
                        c.[Total],
                        cl.[Id] as ClienteId,
                        cl.[Rfc] as RfcCliente,
                        cl.[RazonSocial] as RazonSocialCliente
                        FROM [Cfdi] c
                        LEFT JOIN [Cliente] cl on c.[ClienteId] = cl.[Id]
                        WHERE c.[Id] = @CfdiId;
                        ".ReplaceBracketsWithQuotes();

            var sqlPartidas = @"
                            SELECT
                            p.[Id],
                            p.[Descripcion],
                            p.[Cantidad],
                            p.[ValorUnitario],
                            p.[Importe]
                            FROM [Partida] p
                            WHERE p.[CfdiId] = @CfdiId;
                            ".ReplaceBracketsWithQuotes();

            CfdiVm cfdi;

            using (var multi = connection.QueryMultiple(sqlCfdi + sqlPartidas, new { CfdiId = request.Id }))
            {
                cfdi = multi.Read<CfdiVm>().First();
                cfdi.Partidas = multi.Read<PartidaVm>().ToList();
            }

            if (cfdi == null)
                throw new NotFoundException(nameof(Cfdi), request.Id);

            return cfdi;
        }
    }
}
