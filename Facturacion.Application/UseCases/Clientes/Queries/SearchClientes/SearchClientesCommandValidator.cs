using Facturacion.Application.Common.Validators;
using FluentValidation;
using FluentValidation.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Clientes.Queries.SearchClientes
{
   public class SearchClientesCommandValidator:AbstractValidator<SearchClientesCommand>
    {
        public SearchClientesCommandValidator()
        {
            this.RuleFor(x => x.EmpresaId).GuidNotEmpty();
        }
    }
}
