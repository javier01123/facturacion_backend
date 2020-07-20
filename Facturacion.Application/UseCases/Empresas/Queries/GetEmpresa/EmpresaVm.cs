using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Empresas.GetEmpresa
{
    public class EmpresaVm
    {
        public Guid Id { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string Rfc { get; set; }

    }
}
