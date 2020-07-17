using Dapper;
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.Common.Contracts.Hashing;
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
        private IPasswordHasher _passwordHasher;
        public ValidarCredencialesCommandHandler(ISqlConnectionFactory sqlConnectionFactory, IPasswordHasher passwordHasher)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public async Task<ValidarCredencialesResult> Handle(ValidarCredencialesCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            var sql = @"
                        SELECT
                        u.[Id] as [UsuarioId],                      
                        u.[Email],
                        u.[Password]
                        FROM [Usuario] as u
                        WHERE u.[Email] = @Email 
                        LIMIT 1;
                        ".ReplaceBracketsWithQuotes();

            var usuario = await connection.QuerySingleOrDefaultAsync(sql, new { Email = request.Email });

            if (usuario == null)
                throw new LoginException("usuario o contraseña invalida");

            if (!_passwordHasher.VerifyPassword(request.Password, usuario.Password))
                throw new LoginException("usuario o contraseña invalida");

            var result = new ValidarCredencialesResult()
            {
                Email = usuario.Email,
                UsuarioId = usuario.UsuarioId,
            };

            return result;

        }
    }
}
