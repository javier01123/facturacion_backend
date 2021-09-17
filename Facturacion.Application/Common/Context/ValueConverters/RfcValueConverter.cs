using Facturacion.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.Persistence.ValueConverters
{
    public class RfcValueConverter:ValueConverter<Rfc, string>
    {
        public RfcValueConverter(ConverterMappingHints mappingHints = null)
           : base(rfc => rfc.Value, value => Create(value), mappingHints)
        {
        }

        private static Rfc Create(string value) => Activator.CreateInstance(typeof(Rfc), value) as Rfc;
    }
}
