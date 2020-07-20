using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Domain.Exceptions
{
    public class InvalidParameterException : DomainException
    {
        public InvalidParameterException(string message) : base(message)
        {
        }
    }
}
