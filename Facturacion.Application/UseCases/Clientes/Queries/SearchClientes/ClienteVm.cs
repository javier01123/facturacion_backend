using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Clientes.Queries.SearchClientes
{
    public class ClienteVm
    {
        public Guid Id { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
    }
}
