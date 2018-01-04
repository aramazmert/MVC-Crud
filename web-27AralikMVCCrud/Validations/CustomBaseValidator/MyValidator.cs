using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_27AralikMVCCrud.Data.Entities;
using web_27AralikMVCCrud.Repositories.Abstracts;
using web_27AralikMVCCrud.Repositories.Concretes;

namespace web_27AralikMVCCrud.Validations.CustomBaseValidator
{
    public class MyValidator : BaseValidator<Category>
    {
        public MyValidator(IRepository<Category> baseRepo) : base(baseRepo)
        {
        }

        public override void InitConfig()
        {
            throw new NotImplementedException();
        }
    }

    public class My2Validator : MyValidator
    {
        public My2Validator(IRepository<Category> baseRepo) : base(baseRepo)
        {
        }

        public override void InitConfig()
        {
            base.InitConfig();
        }
    }
}