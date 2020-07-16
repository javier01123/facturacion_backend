using Dapper;
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.UseCases.Clientes.Queries.SearchClientes
{
    public class SearchClientesCommandHandler : IRequestHandler<SearchClientesCommand, IEnumerable<ClienteVm>>
    {

        private ISqlConnectionFactory _sqlConnectionFactory;
        public SearchClientesCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
        }
        public async Task<IEnumerable<ClienteVm>> Handle(SearchClientesCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            var sql = @"SELECT  
                        c.[Id],  
                        c.[RazonSocial],                                  
                        c.[Rfc]  
                        FROM [Cliente] AS c  
                        WHERE c.[EmpresaId]=@EmpresaId
                        AND ( c.[RazonSocial] ILIKE @SearchTerm
                        OR c.[Rfc] LIKE @SearchTerm)
                        LIMIT 10;   
                        ".ReplaceBracketsWithQuotes();

            var clientes = await connection.QueryAsync<ClienteVm>(sql, new
            {
                EmpresaId = request.EmpresaId,
                SearchTerm = "%"+ request.SearchTerm + "%" 
            }
            );

            return clientes;
        }
    }
}
