using Dapper;
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.UseCases.Sucursales.Queries.GetSucursales
{
    public class GetSucursalesCommandHandler : IRequestHandler<GetSucursalesCommand, IEnumerable<SucursalDto>>
    {
        private ISqlConnectionFactory _sqlConnectionFactory;

        public GetSucursalesCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
        }
        public async Task<IEnumerable<SucursalDto>> Handle(GetSucursalesCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            var sql = @"
                        SELECT 
                        s.[Id],
                        s.[EmpresaId],
                        s.[Nombre]                   
                        FROM [Sucursal] as s
                        WHERE s.[EmpresaId] = @EmpresaId;                      
                        ".ReplaceBracketsWithQuotes();

            var sucursales = await connection.QueryAsync<SucursalDto>(sql, new { EmpresaId = request.EmpresaId });
            return sucursales;
        }
    }
}
