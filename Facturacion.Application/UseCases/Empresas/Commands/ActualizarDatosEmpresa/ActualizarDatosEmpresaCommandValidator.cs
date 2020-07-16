using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Empresas.ActualizarDatosEmpresa
{
    public class ActualizarDatosEmpresaCommandValidator : AbstractValidator<ActualizarDatosEmpresaCommand>
    {
        public ActualizarDatosEmpresaCommandValidator()
        {
            this.RuleFor(x => x.NombreComercial).NotEmpty().WithMessage("Nombre Comercial es obligatorio.");
            this.RuleFor(x => x.RazonSocial).NotEmpty().WithMessage("Razón Social es obligatoria.");
        }
    }
}
