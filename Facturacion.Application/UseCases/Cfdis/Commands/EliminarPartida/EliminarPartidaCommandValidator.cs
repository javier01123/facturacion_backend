using Facturacion.Application.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Commands.EliminarPartida
{
    public class EliminarPartidaCommandValidator : AbstractValidator<EliminarPartidaCommand>
    {
        public EliminarPartidaCommandValidator()
        {
            this.RuleFor(x => x.CfdiId).GuidNotEmpty().WithMessage("El CfdiId es obligatorio");
            this.RuleFor(x => x.PartidaId).GuidNotEmpty().WithMessage("El PartidaId es obligatorio");
        }
    }
}
