using System;
using System.Data.Entity;

namespace Infra.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        DbContext Db { get; }

        void StartTransaction();
    }
}
