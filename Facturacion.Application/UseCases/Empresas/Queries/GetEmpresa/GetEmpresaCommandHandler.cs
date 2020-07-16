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

namespace Facturacion.Application.UseCases.Empresas.GetEmpresa
{
    public class GetEmpresaCommandHandler : IRequestHandler<GetEmpresaCommand, EmpresaDto>
    {
        private ISqlConnectionFactory _sqlConnectionFactory;

        public GetEmpresaCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
        }

        public async Task<EmpresaDto> Handle(GetEmpresaCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

              var sql = @"SELECT                                
                        e.[Id],
                        e.[RazonSocial], 
                        e.[NombreComercial], 
                        e.[Rfc]
                        FROM [Empresa] AS e 
                        WHERE e.[Id] = @EmpresaId
                        LIMIT 1;
                        ".ReplaceBracketsWithQuotes();

            var empresaDto = await connection.QuerySingleOrDefaultAsync<EmpresaDto>(sql, new
            {
                EmpresaId = request.Id
            });

            if (empresaDto == null)
                throw new NotFoundException(nameof(Empresa), request.Id);

            return empresaDto;
        }
    }
}
