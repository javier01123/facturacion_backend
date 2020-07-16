using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Usuarios.Queries.ValidarCredenciales
{
    public class ValidarCredencialesCommandValidator:AbstractValidator<ValidarCredencialesCommand>
    {
        public ValidarCredencialesCommandValidator()
        {

        }
    }
}
