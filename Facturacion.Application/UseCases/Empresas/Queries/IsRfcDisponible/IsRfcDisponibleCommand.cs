using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Application.UseCases.Empresas.Queries.IsRfcDisponible
{
    public class IsRfcDisponibleCommand:IRequest<bool>
    {
        public string Rfc { get; set; }
    }
}
