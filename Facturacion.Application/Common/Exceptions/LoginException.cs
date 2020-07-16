using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.Common.Exceptions
{
    public class LoginException : ApplicationLayerException
    {
        public LoginException(string message) : base(message)
        {
        }
    }
}
