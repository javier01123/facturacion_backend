using Facturacion.Application.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.Common.Context.Extensions
{
    public static class ContextExtensions
    {
        public static async Task<int> GetSiguienteFolioDisponibleAsync(this FacturacionContext context, Guid sucursalId)
        {
            var ultimoFolioUsuado = await context.Cfdi.Where(m => m.Id == sucursalId).MaxAsync(m => (int?)m.Folio) ?? 0;
            return ultimoFolioUsuado + 1;
        }
    }
}
