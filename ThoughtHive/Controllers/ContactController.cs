using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThoughtHive.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager manager = new ContactManager(new EFContactDal());
        ContactValidator validator = new ContactValidator();
        public ActionResult Index()
        {
            var values = manager.GetListBL();
            return View(values);
        }

        public ActionResult GetContactDetails(int id)

        {
            var values = manager.GetByIDBL(id);
            return View(values);  
        }

        public PartialViewResult PartialMenu()
        {
            return PartialView();

        }
    }
}