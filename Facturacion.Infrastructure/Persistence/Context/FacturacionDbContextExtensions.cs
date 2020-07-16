using Facturacion.Domain.Aggregates;
using Facturacion.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Infrastructure.Persistence.Context
{
    public static class FacturacionDbContextExtensions
    {
        public async static Task<Empresa> FindByRfcAsync(this DbSet<Empresa> empresas, Rfc rfc)
        {
            //return await empresas.Where(m => m.Rfc.Value == rfc).FirstOrDefaultAsync();
            return await empresas.Where(m => m.Rfc == rfc).FirstOrDefaultAsync();


        }
    }
}
