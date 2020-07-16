using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.Common.Exceptions
{
    public class RfcEmpresaDuplicadoException : ApplicationLayerException
    {

        public RfcEmpresaDuplicadoException(string rfc)
            : base($"Ya existe una empresa con el RFC:{rfc}")
        {

        }

    }
}
