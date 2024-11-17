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
    public class AboutController : Controller
    {   
        // GET: About
        AboutManager manager = new AboutManager(new EFAboutDal());
        public ActionResult Index()
        {
            var values = manager.GetListBL();
            return View(values);
        }

        public ActionResult AddAbout()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            manager.AboutAdd(about);
            return RedirectToAction("Index", "About");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}