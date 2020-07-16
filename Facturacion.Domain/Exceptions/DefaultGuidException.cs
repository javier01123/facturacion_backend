using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Domain.Exceptions
{
    public class DefaultGuidException: DomainException
    {
        internal DefaultGuidException() : base("El Id default no es permitido")
        {

        }
    }
}
