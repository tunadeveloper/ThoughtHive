using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThoughtHive.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cM = new CategoryManager();

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var values = cM.GetAllBL();
            return View(values);
        }

    }
}