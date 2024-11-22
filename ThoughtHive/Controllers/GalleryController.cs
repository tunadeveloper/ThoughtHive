using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThoughtHive.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager manager = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var values = manager.GetListBL();
            return View(values);
        }
    }
}