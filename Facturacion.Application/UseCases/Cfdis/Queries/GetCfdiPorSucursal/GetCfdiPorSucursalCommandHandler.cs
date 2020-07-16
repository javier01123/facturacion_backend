using Dapper;
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.UseCases.Cfdis.Queries.GetCfdiPorSucursal
{
    public class GetCfdiPorSucursalCommandHandler : IRequestHandler<GetCfdiPorSucursalCommand, IEnumerable<CfdiItemVm>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetCfdiPorSucursalCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
        }
        public async Task<IEnumerable<CfdiItemVm>> Handle(GetCfdiPorSucursalCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            var sql = @"
                        SELECT
                        c.[Id],
                        c.[Serie],
                        c.[Folio],
                        c.[FechaEmision],
                        c.[Total],
                        cl.[Id] as ClienteId,
                        cl.[Rfc] as RfcCliente,
                        cl.[RazonSocial] as RazonSocialCliente
                        FROM [Cfdi] c
                        LEFT JOIN [Cliente] cl on c.[ClienteId] = cl.[Id]
                        WHERE c.[SucursalId] = @SucursalId
                        ".ReplaceBracketsWithQuotes();

            var cfdis = await connection.QueryAsync<CfdiItemVm>(sql, new { SucursalId = request.SucursalId });
            return cfdis;
        }
    }
}
