using Facturacion.Application.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Empresas.AltaEmpresa
{
    public class AltaEmpresaCommandValidator : AbstractValidator<AltaEmpresaCommand>
    {
        public AltaEmpresaCommandValidator()
        {
            this.RuleFor(x => x.NombreComercial).NotEmpty().WithMessage("Nombre Comercial es obligatorio.");
            this.RuleFor(x => x.RazonSocial).NotEmpty().WithMessage("Razón Social es obligatoria.");
            this.RuleFor(x => x.Rfc).FormatoRfc();
            this.RuleFor(x => x.Id).GuidNotEmpty();
         }
    }
}
