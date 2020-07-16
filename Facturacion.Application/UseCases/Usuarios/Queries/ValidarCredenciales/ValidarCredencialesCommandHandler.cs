using Dapper;
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Exceptions;
using Facturacion.Application.Common.Extensions;
using FluentValidation.TestHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturacion.Application.UseCases.Usuarios.Queries.ValidarCredenciales
{
    public class ValidarCredencialesCommandHandler : IRequestHandler<ValidarCredencialesCommand, ValidarCredencialesResult>
    {
        private ISqlConnectionFactory _sqlConnectionFactory;
        public ValidarCredencialesCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
        }

        public async Task<ValidarCredencialesResult> Handle(ValidarCredencialesCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            var sql = @"
                        SELECT
                        u.[Id] as UsuarioId,
                        u.[Email]
                        FROM [Usuario] as u
                        WHERE u.[Email] = @Email 
                        AND u.[Password] = @Password
                        LIMIT 1;
                        ".ReplaceBracketsWithQuotes();

            var result = await connection.QuerySingleOrDefaultAsync<ValidarCredencialesResult>(sql, new { Email = request.Email, Password = request.Password });

            if (result == null)
                throw new LoginException("usuario o contraseña invalida");

            result = new ValidarCredencialesResult()
            {
                Email = request.Email,
                UsuarioId = result.UsuarioId,
            };

            return result;

        }
    }
}
