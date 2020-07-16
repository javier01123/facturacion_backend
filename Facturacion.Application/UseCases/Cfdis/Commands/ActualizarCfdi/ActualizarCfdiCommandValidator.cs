using Facturacion.Application.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Commands.ActualizarCfdi
{
    public class ActualizarCfdiCommandValidator : AbstractValidator<ActualizarCfdiCommand>
    {
        public ActualizarCfdiCommandValidator()
        {
            RuleFor(x => x.FechaEmision).NotNull().WithMessage("La Fecha de Emision es obligatoria");
            RuleFor(x => x.Id).GuidNotEmpty();
            RuleFor(x => x.ClienteId).GuidNotEmpty();
        }
    }
}
