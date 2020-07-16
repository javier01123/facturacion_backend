using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Clientes.Queries.GetCliente
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public Guid EmpresaId { get; set; }
        public string RazonSocial { get; set; }
        public string Rfc { get; set; }

    }
}
