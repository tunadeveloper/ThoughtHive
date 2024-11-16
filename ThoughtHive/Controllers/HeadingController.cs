using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThoughtHive.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading

        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        public ActionResult Index()
        {
            var value = headingManager.GetList();
            return View(value);
        }

        public ActionResult AddHeading()
        {
            List<SelectListItem> category = (from x in categoryManager.GetList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }).ToList();
            

            List<SelectListItem> writer = (from x in writerManager.GetListBL()
                                           select new SelectListItem
                                           {
                                               Text = x.WriterName + " " + x.WriterSurname,
                                               Value = x.WriterID.ToString()
                                           }).ToList();

            ViewBag.category = category;
            ViewBag.writer = writer;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAddBL(heading);
            return RedirectToAction("Index", "Heading");
        }


        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> category = (from x in categoryManager.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;
            var value = headingManager.GetByID(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {

            headingManager.HeadingUpdateBL(heading);
            return RedirectToAction("Index", "Heading");
        }

        public ActionResult PassiveHeading(int id)
        {
            var value = headingManager.GetByID(id);
            value.HeadingStatus = false;
            headingManager.HeadingPassiveBL(value);
            return RedirectToAction("Index", "Heading");

        }


        public ActionResult ActiveHeading(int id)
        {
            var value = headingManager.GetByID(id);
            value.HeadingStatus = true;
            headingManager.HeadingActiveBL(value);
            return RedirectToAction("Index", "Heading");
        }

    }
}