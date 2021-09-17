using Facturacion.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.Persistence.ValueConverters
{
    public class RfcValueConverterSelector : ValueConverterSelector
    {
        private readonly ConcurrentDictionary<(Type ModelClrType, Type ProviderClrType), ValueConverterInfo> _converters
            = new ConcurrentDictionary<(Type ModelClrType, Type ProviderClrType), ValueConverterInfo>();

        public RfcValueConverterSelector(ValueConverterSelectorDependencies dependencies)
            : base(dependencies)
        {
        }

        public override IEnumerable<ValueConverterInfo> Select(Type modelClrType, Type providerClrType = null)
        {
            var baseConverters = base.Select(modelClrType, providerClrType);
            foreach (var converter in baseConverters)
            {
                yield return converter;
            }

            var underlyingModelType = UnwrapNullableType(modelClrType);
            var underlyingProviderType = UnwrapNullableType(providerClrType);

            if (underlyingProviderType is null || underlyingProviderType == typeof(string))
            {
                var isTypedIdValue = typeof(Rfc).IsAssignableFrom(underlyingModelType);
                if (isTypedIdValue)
                {
                    var converterType = typeof(Rfc);

                    yield return _converters.GetOrAdd((underlyingModelType, typeof(string)), _ =>
                    {
                        return new ValueConverterInfo(
                            modelClrType: modelClrType,
                            providerClrType: typeof(string),
                            factory: valueConverterInfo => (ValueConverter)Activator.CreateInstance(converterType, valueConverterInfo.MappingHints));
                    });
                }
            }
        }

        private static Type UnwrapNullableType(Type type)
        {
            if (type is null)
            {
                return null;
            }

            return Nullable.GetUnderlyingType(type) ?? type;
        }
    }
}
