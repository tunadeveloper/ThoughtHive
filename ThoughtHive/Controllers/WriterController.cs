using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
    }
}