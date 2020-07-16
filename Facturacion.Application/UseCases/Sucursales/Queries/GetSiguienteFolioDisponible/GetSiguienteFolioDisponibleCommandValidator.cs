using Facturacion.Application.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Sucursales.Queries.GetSiguienteFolioDisponible
{
    public class GetSiguienteFolioDisponibleCommandValidator:AbstractValidator<GetSiguienteFolioDisponibleCommand>
    {
        public GetSiguienteFolioDisponibleCommandValidator()
        {
            RuleFor(x => x.SucursalId).GuidNotEmpty();
        }
    }
}
