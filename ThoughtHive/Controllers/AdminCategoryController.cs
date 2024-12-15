using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    [Authorize(Roles = "2")]
    public class AdminCategoryController : Controller
    {
        CategoryManager cM = new CategoryManager(new EFCategoryDal());
        // GET: Admin
        public ActionResult Index()
        {
            var values = cM.GetList();
            return View(values);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult results = validator.Validate(category);
            if (results.IsValid)
            {
                cM.CategoryAddBL(category);
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

        public ActionResult DeleteCategory(int id)
        {
            var value = cM.GetByIDBL(id);
            cM.CategoryDeleteBL(value);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCategory(int id) {
           var value = cM.GetByIDBL(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            cM.CategoryUpdateBL(category);
            return RedirectToAction("Index");
        }
    }
}