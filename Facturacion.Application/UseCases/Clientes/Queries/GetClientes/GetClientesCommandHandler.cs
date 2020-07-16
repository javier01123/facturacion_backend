using Dapper;
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.UseCases.Clientes.Queries.GetListaClientes
{
    public class GetClientesCommandHandler : IRequestHandler<GetClientesCommand, IEnumerable<ClienteItemDto>>
    {

        private ISqlConnectionFactory _sqlConnectionFactory;

        public GetClientesCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
        }
        public async Task<IEnumerable<ClienteItemDto>> Handle(GetClientesCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            var sql = @"SELECT  
                        c.[Id],  
                        c.[RazonSocial],                                  
                        c.[Rfc]  
                        FROM [Cliente] AS c  
                        WHERE c.[EmpresaId]=@EmpresaId
                        ".ReplaceBracketsWithQuotes();

            var clientes = await connection.QueryAsync<ClienteItemDto>(sql, new { EmpresaId = request.EmpresaId });

            return clientes;
        }
    }
}
