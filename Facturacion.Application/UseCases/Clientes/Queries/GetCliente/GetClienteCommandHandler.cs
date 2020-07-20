using Dapper;
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Exceptions;
using Facturacion.Application.Common.Extensions;
using Facturacion.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.UseCases.Clientes.Queries.GetCliente
{
    public class GetClienteCommandHandler : IRequestHandler<GetClienteCommand, ClienteVm>
    {
        private ISqlConnectionFactory _sqlConnectionFactory;

        public GetClienteCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
        }
        public async Task<ClienteVm> Handle(GetClienteCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            string sql = @"SELECT  
                                c.[Id],  
                                c.[RazonSocial],                                  
                                c.[Rfc],
                                c.[EmpresaId]
                                FROM [Cliente] AS c  
                                Where c.[Id]=@Id
                                ".ReplaceBracketsWithQuotes();

            var cliente = await connection.QuerySingleOrDefaultAsync<ClienteVm>(sql, new { Id = request.Id });

            if (cliente == null)
                throw new NotFoundException(nameof(Cliente), request.Id);

            return cliente;
        }
    }
}
