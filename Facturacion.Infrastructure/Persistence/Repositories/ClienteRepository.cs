using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Domain.Aggregates;
using Facturacion.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Infrastructure.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly FacturacionContext _facturacionContext;

        public ClienteRepository(FacturacionContext facturacionContext)
        {
            _facturacionContext = facturacionContext ?? throw new ArgumentNullException(nameof(facturacionContext));
        }

        public void AddCliente(Cliente cliente)
        {
            _facturacionContext.Cliente.Add(cliente);
        }

        public async Task<Cliente> FindById(Guid id)
        {
            return await _facturacionContext.Cliente.FirstOrDefaultAsync(m => m.Id == id);
        }

        public void UpdateCliente(Cliente cliente)
        {
            _facturacionContext.Cliente.Update(cliente);
        }
    }
}
