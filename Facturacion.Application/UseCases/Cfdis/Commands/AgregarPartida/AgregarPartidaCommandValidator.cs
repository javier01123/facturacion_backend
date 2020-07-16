using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Commands.AgregarPartida
{
   public class AgregarPartidaCommandValidator:AbstractValidator<AgregarPartidaCommand>
    {
        public AgregarPartidaCommandValidator()
        {

        }
    }
}
