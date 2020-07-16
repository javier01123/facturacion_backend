using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Domain.SharedKernel
{
    public static class REGEX_PATTERNS
    {
        public const string RFC = "[A-Z&Ñ]{3,4}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[A-Z0-9]{2}[0-9A]";
    }
}
