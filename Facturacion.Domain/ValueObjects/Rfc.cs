using Facturacion.Domain.Exceptions;
using Facturacion.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Facturacion.Domain.ValueObjects
{
    public class Rfc : IEquatable<Rfc>
    {
        public string Value { get; private set; }

        private Rfc()
        {
        }

        public Rfc(string value)
        {
            this.Value = value;
        }

        public static Rfc For(string rfcString)
        {
            var isMatch = Regex.IsMatch(rfcString, REGEX_PATTERNS.RFC);

            if (!isMatch)
                throw new RfcFormatoInvalidoException(rfcString);

            return new Rfc() { Value = rfcString };
        }


        public static bool operator ==(Rfc obj1, Rfc obj2)
        {
            if (object.Equals(obj1, null))
            {
                if (object.Equals(obj2, null))
                {
                    return true;
                }
                return false;
            }
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Rfc x, Rfc y)
        {
            return !(x == y);
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Rfc other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(Rfc other)
        {
            return this.Value == other?.Value;
        }
    }
}
