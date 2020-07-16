using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Usuarios.Queries.ValidarCredenciales
{
    public class ValidarCredencialesResult
    {
        public Guid UsuarioId { get; set; }
        public string Email { get; set; }
    }
}
