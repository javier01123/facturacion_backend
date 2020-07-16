using Facturacion.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Clientes.Commands.CrearCliente
{
    public class CrearClienteCommand:IRequest
    {
        public Guid Id { get; set; }
        public Guid EmpresaId { get; set; }
        public string Rfc { get; set; }
        public string RazonSocial { get; set; }


    }
}
