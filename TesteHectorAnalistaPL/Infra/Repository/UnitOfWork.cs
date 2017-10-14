using Infra.Interfaces.Repository;
using System.Data.Entity;
using System.Transactions;
using Infra.Contexto;

namespace Infra.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope _transaction;
        private readonly MeuContext _context;

        public UnitOfWork()
        {
            _context = new MeuContext();
        }

        public void Dispose()
        {
            if (null != _transaction)
            {
                _transaction.Dispose();
            }

            if (null != _context)
            {
                _context.Dispose();
            }
        }

        public void StartTransaction()
        {
            _transaction = new TransactionScope();
        }

        public void Commit()
        {
            _context.SaveChanges();
            _transaction.Complete();
        }

        public DbContext Db
        {
            get { return _context; }
        }
    }
}
