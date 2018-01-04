using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_27AralikMVCCrud.Repositories.Abstracts;

namespace web_27AralikMVCCrud.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;
        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose(disposing);
        }
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }
    }
}