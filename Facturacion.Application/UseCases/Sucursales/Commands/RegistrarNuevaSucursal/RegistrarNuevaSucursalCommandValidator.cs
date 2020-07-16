using Facturacion.Application.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Empresas.AltaEmpresa
{
    public class RegistrarNuevaEmpresaCommandValidator : AbstractValidator<RegistrarNuevaSucursalCommand>
    {
        public RegistrarNuevaEmpresaCommandValidator()
        {
            this.RuleFor(x => x.Id).GuidNotEmpty();
            this.RuleFor(x => x.EmpresaId).GuidNotEmpty();
            this.RuleFor(x => x.Nombre).NotEmpty().WithMessage("El Nombre es obligatorio."); 
        
         }
    }
}
