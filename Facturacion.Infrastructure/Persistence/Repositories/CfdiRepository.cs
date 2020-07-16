using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Domain.Aggregates;
using Facturacion.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Infrastructure.Persistence.Repositories
{
    public class CfdiRepository : ICfdiRepository
    {
        private readonly FacturacionContext _facturacionContext;

        public CfdiRepository(FacturacionContext facturacionContext)
        {
            _facturacionContext = facturacionContext ?? throw new ArgumentNullException(nameof(facturacionContext));
        }
        public async Task AddCfdi(Cfdi cfdi)
        {
            await _facturacionContext.Cfdi.AddAsync(cfdi);
        }

        public async Task<Cfdi> GetById(Guid id)
        {
            return await _facturacionContext.Cfdi.FirstOrDefaultAsync(m => m.Id == id);
        }

        public void UpdateCfdi(Cfdi cfdi)
        {
            _facturacionContext.Cfdi.Update(cfdi);
        }
    }
}
