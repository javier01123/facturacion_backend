using Facturacion.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Domain.Guards
{
    internal static class Guard
    {
        internal static void GuidNotEmpty(Guid id, string propertyName)
        {
            if (id == Guid.Empty)
                throw new InvalidParameterException($"{propertyName} value cannot be empty!");
        }

        internal static void StringNotEmpty(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidParameterException($"{propertyName} no puede estar vacío!");
        }

        internal static void ValueCannotBeNegative(decimal value, string propertyName)
        {
            if (value < 0)
                throw new InvalidParameterException($"{propertyName} no puede ser negativo");
        }

        internal static void ValueMustBeGreaterThanZero(decimal value, string propertyName)
        {
            if (value <= 0)
                throw new InvalidParameterException($"{propertyName} debe ser mayor a cero");
        }

        //internal static void StringMaxLength(string value, string propertyName, int maxLength)
        //{
        //    if (value.Length > maxLength)
        //        throw new MaxLengthExceededException($"la longitud máxima para {propertyName} es {maxLength}");
        //}
    }
}
