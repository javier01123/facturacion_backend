using Dapper;
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Exceptions;
using Facturacion.Application.Common.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.UseCases.Sucursales.Queries.GetSucursal
{
    public class GetSucursalCommandHandler : IRequestHandler<GetSucursalCommand, SucursalDto>
    {
        private ISqlConnectionFactory _sqlConnectionFactory;

        public GetSucursalCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
        }

        public async Task<SucursalDto> Handle(GetSucursalCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            var sql = @"
                        SELECT
                        s.[Id],
                        s.[EmpresaId],
                        s.[Nombre],
                        sd.[Pais],
                        sd.[Estado],
                        sd.[Ciudad],
                        sd.[Municipio],
                        sd.[Colonia],
                        sd.[CodigoPostal],
                        sd.[Calle],
                        sd.[NumeroInterior],
                        sd.[NumeroExterior]
                        FROM [Sucursal] as s
                        left join [SucursalDomicilio] as sd on s.[Id]=sd.[SucursalId]
                        Where s.[Id] = @Id
                        LIMIT 1;
                        ".ReplaceBracketsWithQuotes();

            var sucursal = await connection.QuerySingleOrDefaultAsync<SucursalDto>(sql, new { Id = request.Id });

            if (sucursal == null)
                throw new NotFoundException(nameof(sucursal), request.Id);

            return sucursal;
        }
    }
}
