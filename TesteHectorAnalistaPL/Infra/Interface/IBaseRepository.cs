using System.Collections.Generic;

namespace Infra.Interfaces.Repository
{
    public interface IBaseRepository<T>
    {
        T Single(object primaryKey);

        T SingleOrDefault(object primaryKey);

        IEnumerable<T> GetAll();

        bool Exists(object primaryKey);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IUnitOfWork UnitOfWork { get; }
    }
}
