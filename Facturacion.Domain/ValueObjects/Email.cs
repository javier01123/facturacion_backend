using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Facturacion.Domain.ValueObjects
{
    public class Email
    {
        private string _value;

        private Email()
        {
        }

        private Email(string email)
        {
            _value = email;
        }
        public static Email Create(string email)
        {
            return new Email(email);
        }

    }
}
