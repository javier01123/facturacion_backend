using Facturacion.Domain.Aggregates;
using Facturacion.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.Common.Context.Extensions
{
    public static class EmpresaExtensions
    {
        public async static Task<Empresa> FindByRfcAsync(this DbSet<Empresa> empresas, Rfc rfc)
        {
            return await empresas.Where(m => m.Rfc == rfc).FirstOrDefaultAsync();
        }

        public static async Task<bool> IsRfcTaken(this DbSet<Empresa> empresas, Rfc rfcVo)
        {
            return await empresas.Where(e => e.Rfc == rfcVo).AnyAsync();            
        }
    }
}
