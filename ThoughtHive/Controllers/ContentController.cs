using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThoughtHive.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager manager = new ContentManager(new EFContentDal()); 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var value = manager.GetListByIDBL(id);
            return View(value);
        }
    }
}