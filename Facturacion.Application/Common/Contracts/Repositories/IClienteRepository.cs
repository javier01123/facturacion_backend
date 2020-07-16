using Facturacion.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.Common.Contracts.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> FindById(Guid id);
        void AddCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
    }
}
