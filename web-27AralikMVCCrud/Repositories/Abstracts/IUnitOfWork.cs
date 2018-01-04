using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_27AralikMVCCrud.Data.Entities;

namespace web_27AralikMVCCrud.Repositories.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        //Transaction yönetimi için rollback ya da commit yapacak.
        //Savechanges() işleminde bunu anlayabiliriz.
        bool Commit();
        //UnitOfWork üzerinden repository'e ulaşmak için kullandığımız bir yöntem.
        IRepository<T> GetRepo<T>() where T : EntityBase, new();
        //UnitOfWork şu işlemleri yapar:
        //1. Repository bağlantısı
        //2. DB bağlantısı. Tek bir yerden yürütülsün.
        //3. Transaction yönetimi.
        void Dispose(bool disposing);
    }
}
