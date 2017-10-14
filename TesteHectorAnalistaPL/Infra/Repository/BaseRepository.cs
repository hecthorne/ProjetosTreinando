using Infra.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        internal DbSet<T> dbSet;
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
            this.dbSet = _unitOfWork.Db.Set<T>();
        }

        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }

        internal DbContext Database { get { return _unitOfWork.Db; } }

        public T Single(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }

        public T SingleOrDefault(object primaryKey)
        {
            var dbResult = dbSet.Find(primaryKey);
            return dbResult;
        }

        public bool Exists(object primaryKey)
        {
            return dbSet.Find(primaryKey) == null ? false : true;
        }

        public virtual void Insert(T entity)
        {
            dynamic obj = dbSet.Add(entity);
            this._unitOfWork.Db.SaveChanges();            
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            
            this._unitOfWork.Db.SaveChanges();
        }

        public void Delete(T entity)
        {
            //if (_unitOfWork.Db.Entry(entity).State == EntityState.Detached)
            //{
            //    dbSet.Attach(entity);
            //}

            //dbSet.Attach(entity);
            //dynamic obj = dbSet.Remove(entity);
            //this._unitOfWork.Db.SaveChanges();

            dbSet.Attach(entity);
            dbSet.Remove(entity);
            _unitOfWork.Db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

    }
}
