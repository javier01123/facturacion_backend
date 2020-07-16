using Facturacion.Domain.SharedKernel;
using Facturacion.Domain.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.Common.Validators
{
    public static class RfcValidator
    {
        public static IRuleBuilderOptions<T, string> FormatoRfc<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            IRuleBuilderOptions<T,string> options;
            options = ruleBuilder.Matches(REGEX_PATTERNS.RFC).WithMessage("RFC no cumple con el formato");
            options = options.Length(12, 13).WithMessage("La longitud del RFC debe ser de {MinLength} a {MaxLength}");
            return options;
        }
    }
}
