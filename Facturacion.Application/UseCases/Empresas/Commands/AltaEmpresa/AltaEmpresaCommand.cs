using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Facturacion.Application.UseCases.Empresas.AltaEmpresa
{
    public class AltaEmpresaCommand:IRequest
    {
        public Guid Id { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string Rfc { get; set; }

        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string Municipio { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string Calle { get; set; }
        public string NumeroInterior { get; set; }
        public string NumeroExterior { get; set; }
    }
}
