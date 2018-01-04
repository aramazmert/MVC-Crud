using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using web_27AralikMVCCrud.Data.Entities;

namespace web_27AralikMVCCrud.Repositories.Abstracts
{
    public interface IRepository<T>
        where T : EntityBase, new()
    {
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> lambda);
        T GetObject(Expression<Func<T, bool>> lambda);
    }
}
