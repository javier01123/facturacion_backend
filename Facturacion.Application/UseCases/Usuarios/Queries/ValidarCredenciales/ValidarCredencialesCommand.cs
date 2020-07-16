using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Usuarios.Queries.ValidarCredenciales
{
    public class ValidarCredencialesCommand : IRequest<ValidarCredencialesResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
