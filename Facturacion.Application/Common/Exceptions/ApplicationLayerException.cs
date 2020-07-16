using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.Common.Exceptions
{
   public abstract class ApplicationLayerException:Exception
    {
        public ApplicationLayerException(string message) : base(message)
        {

        }
    }
}
