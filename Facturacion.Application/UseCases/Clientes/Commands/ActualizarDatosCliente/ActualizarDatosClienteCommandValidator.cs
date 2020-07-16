using Facturacion.Application.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Clientes.Commands.ActualizarDatosCliente
{
    public class ActualizarDatosClienteCommandValidator:AbstractValidator<ActualizarDatosClienteCommand>
    {
        public ActualizarDatosClienteCommandValidator()
        {
            this.RuleFor(x => x.RazonSocial).NotEmpty().WithMessage("Razón Social es obligatoria.");         
            this.RuleFor(x => x.Id).GuidNotEmpty();
        }
    }
}
