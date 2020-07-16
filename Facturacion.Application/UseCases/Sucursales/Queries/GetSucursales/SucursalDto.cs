using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Sucursales.Queries.GetSucursales
{
    public class SucursalDto
    {
        public Guid Id { get; set; }
        public Guid EmpresaId { get; set; }
        public string Nombre { get; set; }
    }
}
