using Dapper;
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Extensions;
using Facturacion.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.UseCases.Empresas.GetListaEmpresas
{
    public class GetListaEmpresasCommandHandler : IRequestHandler<GetListaEmpresasCommand, IEnumerable<EmpresaDto>>
    {
        private ISqlConnectionFactory _sqlConnectionFactory;

        public GetListaEmpresasCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
        }

        public async Task<IEnumerable<EmpresaDto>> Handle(GetListaEmpresasCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            var sql = @"SELECT  
                        e.[Id],  
                        e.[RazonSocial],  
                        e.[NombreComercial],  
                        e.[Rfc]  
                        FROM [Empresa] AS e
                        ORDER BY e.[Rfc]
                        ".ReplaceBracketsWithQuotes();

            var empresas = await connection.QueryAsync<EmpresaDto>(sql);
           
            return empresas;
        }
    }
}
