using Facturacion.Application.Common.Contracts;
using Facturacion.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Facturacion.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FacturacionContext _context;
        private TransactionScope _transaction;

        public UnitOfWork(FacturacionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public TransactionScope StartTransaction()
        {
            _transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            return _transaction;
        }

        public void Commit()
        {            
            _transaction.Complete();
        }
    }
}
