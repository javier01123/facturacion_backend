using Dapper;
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.UseCases.Empresas.Queries.IsRfcDisponible
{
    public class IsRfcDisponibleCommandHandler : IRequestHandler<IsRfcDisponibleCommand, bool>
    {
        private ISqlConnectionFactory _sqlConnectionFactory;
        public IsRfcDisponibleCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
        }
        public async Task<bool> Handle(IsRfcDisponibleCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            var sql = @"
                        SELECT EXISTS(SELECT [Id] 
                        FROM [Empresa]
                        WHERE [Rfc]=@Rfc
                        LIMIT 1)
                        ".ReplaceBracketsWithQuotes();

            bool usado = await connection.QuerySingleOrDefaultAsync<bool>(sql, new
            {
                Rfc = request.Rfc
            });

            return !usado;
        }
    }
}
