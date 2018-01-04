using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using web_27AralikMVCCrud.Data.Entities;
using web_27AralikMVCCrud.Repositories.Abstracts;

namespace web_27AralikMVCCrud.Repositories.Concretes
{
    public class RepositoryBase<T> : IRepository<T>
        where T : EntityBase, new()
    {
        protected DbContext _context;
        protected IDbSet<T> _dbset;
        public RepositoryBase(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbset.Find(id);
            _dbset.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        public T GetObject(System.Linq.Expressions.Expression<Func<T, bool>> lambda)
        {
            return _dbset.FirstOrDefault(lambda);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> lambda)
        {
            return _dbset.Where(lambda).AsEnumerable<T>();
        }
    }
}