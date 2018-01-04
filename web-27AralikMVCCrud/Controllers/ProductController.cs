using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_27AralikMVCCrud.Data.Entities;
using web_27AralikMVCCrud.Repositories.Abstracts;
using web_27AralikMVCCrud.Validations.ProductsValidations;

namespace web_27AralikMVCCrud.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IUnitOfWork unitOfWork, IProductRepository productRepo) : base(unitOfWork)
        {
            _productRepo = productRepo;
        }
        IEnumerable<SelectListItem> CategoryDrp
        {
            get
            {
                return _unitOfWork
                    .GetRepo<Category>()
                    .GetAll()
                    .Select(a => new SelectListItem
                    {
                        Text = a.Name,
                        Value = a.Id.ToString()
                    })
                    .ToList();
            }
        }

        // GET: Product
        public ActionResult Add()
        {
            ViewBag.Categories = CategoryDrp;
            return View();
        }
        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Add(Product model)
        {
            var validator = new ProductAddValidator(_productRepo).Validate(model);
            if (validator.IsValid)
            {
                _unitOfWork.GetRepo<Product>().Add(model);
                bool IsSuccess = _unitOfWork.Commit();
                ViewBag.IsSuccess = IsSuccess;
                ViewBag.Message = IsSuccess ? "Başarılı" : "Tekrar deneyiniz.";
            }
            validator.Errors.ToList().ForEach(a =>
            {
                ModelState.AddModelError(a.PropertyName, a.ErrorMessage);
            });
            ViewBag.Categories = CategoryDrp;
            return View();
        }
    }
}