using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.Common.Exceptions
{
    public class BadRequestException : ApplicationLayerException
    {
        public BadRequestException(string message)
          : base(message)
        {
        }
    }
}
