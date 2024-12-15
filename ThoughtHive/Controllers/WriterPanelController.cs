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
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading()
        {
            var values = headingManager.GetListByWriterBL();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> category = (from x in categoryManager.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = 4;
            heading.HeadingStatus = true;
            headingManager.HeadingAddBL(heading);
            return RedirectToAction("MyHeading", "WriterPanel");
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
            return RedirectToAction("MyHeading", "WriterPanel");
        }

        public ActionResult PassiveHeading(int id)
        {
            var value = headingManager.GetByID(id);
            value.HeadingStatus = false;
            headingManager.HeadingPassiveBL(value);
            return RedirectToAction("MyHeading", "WriterPanel");

        }
    }
}