using Facturacion.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Domain.Aggregates
{
    public class Usuario
    {
        private Guid _id;
        private Email _email;
        private string _password;
        private Usuario()
        {
        }

        private Usuario(Guid id, Email email, string password)
        {
            _id = id;
            _email = email;
            _password = password;
        }
        //TODO: password debe estar hasheado en la base de datos

        public static Usuario Create(Guid id, string email, string password)
        {
            var emailVo = Email.Create(email);
            return new Usuario(id, emailVo, password);
        }

    }
}
