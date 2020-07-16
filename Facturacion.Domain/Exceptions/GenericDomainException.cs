using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Domain.Exceptions
{
    public class GenericDomainException : DomainException
    {
        public GenericDomainException(string message) : base(message)
        {
        }
    }
}
