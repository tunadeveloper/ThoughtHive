﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ThoughtHive.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cM = new CategoryManager(new EFCategoryDal());

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
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
            FluentValidation.Results.ValidationResult results = validator.Validate(category);
            if (results.IsValid)
            {
                cM.CategoryAddBL(category);
                return RedirectToAction("GetCategoryList");
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
