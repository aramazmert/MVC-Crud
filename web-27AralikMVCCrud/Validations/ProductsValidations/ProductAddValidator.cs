using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using web_27AralikMVCCrud.Repositories.Abstracts;

namespace web_27AralikMVCCrud.Validations.ProductsValidations
{
    public class ProductAddValidator : ProductValidator
    {
        public ProductAddValidator(IProductRepository proRepo) : base(proRepo)
        {
        }
        public override void InitConfig()
        {
            base.InitConfig();
            RuleFor(x => x.Name).Must(UniqeNameCheck).WithMessage("Aynı isimli ürün bulunmaktadır.");
        }
        public bool UniqeNameCheck(string name)
        {
            var data = _proRepo.Where(x => x.Name == name).FirstOrDefault();
            if (data == null)
            {
                return true;
            }
            return false;
        }
    }
}