using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Facturacion.Application.Common.Exceptions
{
    public class ValidationException : ApplicationLayerException
    {
        public ValidationException()
            : base("Han ocurrido uno o mas errores de validación.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            var failureGroups = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

            foreach (var failureGroup in failureGroups)
            {
                var propertyName = failureGroup.Key;
                var propertyFailures = failureGroup.ToArray();

                Errors.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
