using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using web_27AralikMVCCrud.Data.Entities;
using web_27AralikMVCCrud.Repositories.Abstracts;

namespace web_27AralikMVCCrud.Repositories.Concretes
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}