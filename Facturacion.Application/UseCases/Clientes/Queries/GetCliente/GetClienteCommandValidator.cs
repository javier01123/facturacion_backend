using Facturacion.Application.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Facturacion.Application.UseCases.Clientes.Queries.GetCliente
{
    public class GetClienteCommandValidator:AbstractValidator<GetClienteCommand>
    {
        public GetClienteCommandValidator()
        {
            this.RuleFor(x => x.Id).GuidNotEmpty();
        }
    }
}
