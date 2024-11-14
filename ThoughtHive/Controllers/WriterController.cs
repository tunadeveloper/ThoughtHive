using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThoughtHive.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wM = new WriterManager(new EFWriterDal());
        // GET: Writer
        public ActionResult Index()
        {
            var values = wM.GetListBL();
            return View(values);
        }

        public ActionResult UpdateWriter(int id)
        {
            var value = wM.GetByIDBL(id);
            return View(value);
        }

        public ActionResult UpdateWriter(Writer writer)
        {
            wM.WriterUpdateBL(writer);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteWriter(int id)
        {
            var value = wM.GetByIDBL(id);
            wM.WriterDeleteBL(value);
            return RedirectToAction("Index");
        }

        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult results = validator.Validate(writer);
            if (results.IsValid)
            {
                wM.WriterAddBL(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}