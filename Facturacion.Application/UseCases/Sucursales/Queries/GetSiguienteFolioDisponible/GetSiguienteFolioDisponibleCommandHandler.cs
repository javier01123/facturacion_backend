using Dapper;
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.UseCases.Sucursales.Queries.GetSiguienteFolioDisponible
{
    public class GetSiguienteFolioDisponibleCommandHandler : IRequestHandler<GetSiguienteFolioDisponibleCommand, int>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetSiguienteFolioDisponibleCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
        }
        public async Task<int> Handle(GetSiguienteFolioDisponibleCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            var sql = @"
                        SELECT 
                        coalesce(MAX(c.[Folio]),0)+1
                        FROM [Cfdi] c
                        WHERE c.[SucursalId] = @SucursalId
                        ".ReplaceBracketsWithQuotes();

            int siguienteFolio = await connection.QuerySingleAsync<int>(sql, new { SucursalId = request.SucursalId });
            return siguienteFolio;
        }
    }
}
