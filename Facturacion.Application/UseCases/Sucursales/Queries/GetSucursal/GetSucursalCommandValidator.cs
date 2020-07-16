using Facturacion.Application.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Sucursales.Queries.GetSucursal
{
    public class GetSucursalCommandValidator : AbstractValidator<GetSucursalCommand>
    {
        public GetSucursalCommandValidator()
        {
            this.RuleFor(x => x.Id).GuidNotEmpty();
        }
    }
}
