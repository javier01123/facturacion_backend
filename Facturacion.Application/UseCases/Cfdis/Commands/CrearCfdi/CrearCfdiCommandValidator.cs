using Facturacion.Application.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Commands.CrearCfdi
{
    public class CrearCfdiCommandValidator : AbstractValidator<CrearCfdiCommand>
    {
        public CrearCfdiCommandValidator()
        {
            RuleFor(x => x.FechaEmision).NotNull().WithMessage("La Fecha de Emision es obligatoria");
            RuleFor(x => x.Id).GuidNotEmpty();
            RuleFor(x => x.ClienteId).GuidNotEmpty();
            RuleFor(x => x.SucursalId).GuidNotEmpty();
            RuleFor(x => x.Serie).NotEmpty().WithMessage("La Serie es obligatoria");
        }
    }
}
