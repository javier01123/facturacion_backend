using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Sucursales.ActualizarDatosSucursal
{
 
    public class ActualizarDatosSucursalCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
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
