using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Facturacion.Domain.Exceptions
{
    public class RfcFormatoInvalidoException : DomainException
    {
        internal RfcFormatoInvalidoException(string rfc):base($"RFC \"{rfc}\" es invalido.")
        {
        }
    }
}
