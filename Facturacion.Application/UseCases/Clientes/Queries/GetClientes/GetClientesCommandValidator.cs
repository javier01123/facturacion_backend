using Facturacion.Application.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Clientes.Queries.GetListaClientes
{
    public class GetClientesCommandValidator : AbstractValidator<GetClientesCommand>
    {
        public GetClientesCommandValidator()
        {
            this.RuleFor(x => x.EmpresaId).GuidNotEmpty();
        }
    }
}
