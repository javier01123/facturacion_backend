using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Clientes.Commands.ActualizarDatosCliente
{
    public class ActualizarDatosClienteCommand : IRequest
    {
        public Guid Id { get; set; }
        public string RazonSocial { get; set; }

    }
}
