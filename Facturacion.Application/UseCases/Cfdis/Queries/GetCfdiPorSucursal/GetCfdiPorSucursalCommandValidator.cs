using Facturacion.Application.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Facturacion.Application.UseCases.Cfdis.Queries.GetCfdiPorSucursal
{
    public class GetCfdiPorSucursalCommandValidator : AbstractValidator<GetCfdiPorSucursalCommand>
    {

        public GetCfdiPorSucursalCommandValidator()
        {
            RuleFor(x => x.SucursalId).GuidNotEmpty();
        }

    }
}
