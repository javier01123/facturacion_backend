using Facturacion.Application.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Sucursales.Queries.GetSucursales
{
    public class GetSucursalesCommandValidator : AbstractValidator<GetSucursalesCommand>
    {
        public GetSucursalesCommandValidator()
        {
            this.RuleFor(x => x.EmpresaId).GuidNotEmpty();
        }
    }
}
