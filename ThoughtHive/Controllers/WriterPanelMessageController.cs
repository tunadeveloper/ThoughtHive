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
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage

        MessageManager manager = new MessageManager(new EFMessageDal());
        MessageValidator validator = new MessageValidator();

        public ActionResult Inbox()
        {
            var values = manager.GetListInboxBL();
            return View(values);
        }
    }
}