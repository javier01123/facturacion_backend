using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Empresas.ActualizarDatosEmpresa
{
 
    public class ActualizarDatosEmpresaCommand : IRequest
    {
        public Guid Id { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
 
    }
}
