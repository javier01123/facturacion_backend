using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.Common.Extensions
{
    public static class StringExtensions
    {

        public static string ReplaceBracketsWithQuotes(this string value)
        {
            return value.Replace("[", "\"").Replace("]", "\"");
        }
    }
}
