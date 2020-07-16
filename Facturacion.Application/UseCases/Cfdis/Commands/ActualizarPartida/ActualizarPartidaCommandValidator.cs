using Facturacion.Application.Common.Validators;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Commands.ActualizarPartida
{
    public class ActualizarPartidaCommandValidator : AbstractValidator<ActualizarPartidaCommand>
    {
        public ActualizarPartidaCommandValidator()
        {
            RuleFor(x => x.CfdiId).GuidNotEmpty();
            RuleFor(x => x.Id).GuidNotEmpty();
        }
    }
}
