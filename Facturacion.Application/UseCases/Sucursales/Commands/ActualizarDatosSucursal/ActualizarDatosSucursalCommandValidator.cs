using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Sucursales.ActualizarDatosSucursal
{
    public class ActualizarDatosSucursalCommandValidator : AbstractValidator<ActualizarDatosSucursalCommand>
    {
        public ActualizarDatosSucursalCommandValidator()
        {
            this.RuleFor(x => x.Nombre).NotEmpty().WithMessage("Nombre es obligatorio.");
        }
    }
}
