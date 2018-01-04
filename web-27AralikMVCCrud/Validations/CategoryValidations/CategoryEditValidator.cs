using web_27AralikMVCCrud.Data.Entities;
using web_27AralikMVCCrud.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace web_27AralikMVCCrud.Validations.CategoryValidations
{
    public class CategoryEditValidator:CategoryValidator
    {
        public CategoryEditValidator(ICategoryRepository catRepo) : base(catRepo)
        {
           
        }

        public override void InitConfig()
        {
            base.InitConfig();
            RuleFor(x => x).Must(HasSameCategory).WithMessage("Aynı isimde kategori mevcuttur.");
        }

        public bool HasSameCategory(Category model)
        {
            //sistemde var olan ismi tekrar kullanacak şekilde kategoriyi güncellememize izin vermemesi lazım
            //gönderinIsim databasede gönderilenId dışındaki bir kategori ismi mi ?
            //böyle bir kayıt varsa null değilse o zaman bunu güncelleyemeyiz.
            var data = _catRepo.Where(x => x.Name == model.Name && x.Id != model.Id).ToList();

            if (data == null)
            {
                return true;
            }

            return false;
        }
    }
}