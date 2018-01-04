using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_27AralikMVCCrud.Data.Entities;
using web_27AralikMVCCrud.Repositories.Abstracts;
using web_27AralikMVCCrud.Validations;
using web_27AralikMVCCrud.Validations.CategoryValidations;

namespace web_27AralikMVCCrud.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(IUnitOfWork unitOfWork, ICategoryRepository categoryRepo) : base(unitOfWork)
        {
            _categoryRepo = categoryRepo;
        }

        // GET: Category
        public ActionResult List()
        {
            var model = _unitOfWork.GetRepo<Category>().GetAll();
            return View(model);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            var validator = new CategoryAddValidator(_categoryRepo).Validate(model);
            if (validator.IsValid)
            {
                _unitOfWork.GetRepo<Category>().Add(model);
                bool IsSuccess = _unitOfWork.Commit();
                ViewBag.IsSuccess = IsSuccess;
                ViewBag.Message = IsSuccess ? "Başarılı" : "Tekrar deneyiniz.";
            }
            //Hata mesajlarını MVC'ye tanıtmış olduk.
            validator.Errors.ToList().ForEach(a =>
            {
                ModelState.AddModelError(a.PropertyName, a.ErrorMessage);
            });
            //foreach (var item in validator.Errors)
            //{
            //    ModelState.AddModelError(item.ErrorCode, item.ErrorMessage);
            //}
            return View();
        }
        public ActionResult Edit(int id)
        {
            var model = _unitOfWork.GetRepo<Category>().GetObject(x => x.Id == id);
            return View(model);
        }
        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            var validator = new CategoryAddValidator(_categoryRepo).Validate(model);
            if (validator.IsValid)
            {
                _unitOfWork.GetRepo<Category>().Update(model);
                bool IsSuccess = _unitOfWork.Commit();
                ViewBag.IsSuccess = IsSuccess;
                ViewBag.Message = IsSuccess ? "Güncelleme başarılı." : "Güncelleme başarısız.";
            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            _unitOfWork.GetRepo<Category>().Delete(id);
            bool IsSuccess = _unitOfWork.Commit(); //SaveChanges işlemi için çalıştırdık.
            TempData["Message"] = IsSuccess ? "Başarılı." : "Silme işlemini tekrar deneyiniz.";
            //Eğer farklı bir controllera yönlendirilecek ise controller ve action ismi yazılmalıdır.
            //return RedirectToAction("List", "Product");
            //Aynı controllerdaysak sadece Action ismi yeterlidir.
            //Eğer bir actiondan başka bir actiona mesaj göndermek istersek bunu viewbag ya da viewdata ile yapamıyoruz. Bunun yerine tempdata kullanabiliyoruz.
            return RedirectToAction("List");
            //return Redirect("/Category/List"); -> Link yazarak yönlendirme.
        }
    }
}