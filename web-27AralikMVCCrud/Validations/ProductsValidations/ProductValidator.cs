using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_27AralikMVCCrud.Data.Entities;
using web_27AralikMVCCrud.Repositories.Abstracts;

namespace web_27AralikMVCCrud.Validations.ProductsValidations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        protected IProductRepository _proRepo;
        public ProductValidator(IProductRepository proRepo)
        {
            _proRepo = proRepo;
            InitConfig();
        }
        public virtual void InitConfig()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("En fazla 20 karakter olabilir.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Ürün fiyatı 0 girilemez.");
        }
    }
}