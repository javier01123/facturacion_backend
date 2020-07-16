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
            this.RuleFor(x => x.FechaEmision).NotNull().WithMessage("La Fecha de Emision es obligatoria");
            this.RuleFor(x => x.Id).GuidNotEmpty().WithMessage("El Id es obligatorio");
            this.RuleFor(x => x.Serie).NotEmpty().WithMessage("La Serie es obligatoria");
        }
    }
}
