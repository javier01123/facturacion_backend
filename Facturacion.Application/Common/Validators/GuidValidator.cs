using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.Common.Validators
{
    public static class GuidValidator
    {
        public static IRuleBuilderOptions<T, Guid> GuidNotEmpty<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        {
            return ruleBuilder.NotEqual(Guid.Empty).WithMessage("El {PropertyName} es obligatorio");
        }

    }
}
