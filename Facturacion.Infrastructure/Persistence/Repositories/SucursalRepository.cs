using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Domain.Aggregates;
using Facturacion.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Infrastructure.Persistence.Repositories
{
    public class SucursalRepository : ISucursalRepository
    {
        private FacturacionContext _facturacionContext;

        public SucursalRepository(FacturacionContext facturacionContext)
        {
            _facturacionContext = facturacionContext ?? throw new ArgumentNullException(nameof(facturacionContext));
        }

        public void AddSucursal(Sucursal sucursal)
        {
            _facturacionContext.Sucursal.Add(sucursal);
        }

        public async Task<Sucursal> FindById(Guid id)
        {
            return await _facturacionContext.Sucursal.FirstOrDefaultAsync(m => m.Id == id);
        }

        public void UpdateSucursal(Sucursal sucursal)
        {
            _facturacionContext.Sucursal.Update(sucursal);
        }

        public async Task<int> GetSiguienteFolioDisponible(Guid sucursalId)
        {
 
            var ultimoFolioUsuado = await _facturacionContext.Cfdi.Where(m=>m.SucursalId==sucursalId).MaxAsync(m => (int?)m.Folio) ?? 0;
            return ultimoFolioUsuado+1;
        }
    }
}
