using FluentValidation;
using web_27AralikMVCCrud.Data.Entities;
using web_27AralikMVCCrud.Repositories.Abstracts;
using web_27AralikMVCCrud.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_27AralikMVCCrud.Validations.CustomBaseValidator
{
    public abstract class BaseValidator<T> : AbstractValidator<T> where T : EntityBase, new()
    {
        protected IRepository<T> _baseRepo;
        public BaseValidator(IRepository<T> baseRepo)
        {
            _baseRepo = baseRepo;
            InitConfig();
        }
        public abstract void InitConfig();
    }
}