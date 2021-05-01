using Facturacion.Application.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace TestsCommon.Fakes
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        
        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public TransactionScope StartTransaction()
        {
            return null;
        }

        public void Commit()
        {
        }
    }
}
