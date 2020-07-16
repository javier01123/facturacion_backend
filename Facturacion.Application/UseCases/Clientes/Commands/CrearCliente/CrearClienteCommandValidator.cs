using Facturacion.Application.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Clientes.Commands.CrearCliente
{
    public class CrearClienteCommandValidator : AbstractValidator<CrearClienteCommand>
    {
        public CrearClienteCommandValidator()
        {            
            this.RuleFor(x => x.RazonSocial).NotEmpty().WithMessage("Razón Social es obligatoria.");
            this.RuleFor(x => x.Rfc).FormatoRfc();
            this.RuleFor(x => x.Id).GuidNotEmpty();
            this.RuleFor(x => x.EmpresaId).GuidNotEmpty();
        }
    }
}
