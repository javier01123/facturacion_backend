
using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Domain.Aggregates;
using Facturacion.Domain.ValueObjects;
using Facturacion.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Facturacion.Infrastructure.Persistence.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private FacturacionContext _facturacionContext;

        public EmpresaRepository(FacturacionContext facturacionContext)
        {
            _facturacionContext = facturacionContext ?? throw new ArgumentNullException(nameof(facturacionContext));
        }

        public async Task<Empresa> FindByRfc(Rfc rfc)
        {
            return await _facturacionContext.Empresa.FindByRfcAsync(rfc);
        }

        public void AddEmpresa(Empresa empresa)
        {
            _facturacionContext.Empresa.Add(empresa);
        }

        public Task<bool> TieneDocumentosTimbrados(Guid empresaId)
        {
            throw new NotImplementedException();
        }

        public async Task<Empresa> FindById(Guid id)
        {
            return await _facturacionContext.Empresa.FirstOrDefaultAsync(m => m.Id == id);
        }

        public void UpdateEmpresa(Empresa empresa)
        {
            _facturacionContext.Empresa.Update(empresa);
        }
    }
}
