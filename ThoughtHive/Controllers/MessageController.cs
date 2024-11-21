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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager manager = new MessageManager(new EFMessageDal());
        public ActionResult Inbox()
        {
            var values = manager.GetListInboxBL();
            return View(values);
        }
        public ActionResult Sendbox()
        {
            var values = manager.GetListSendboxBL();
            return View(values);
        }

        public ActionResult CreateMessage()
        {
            return View();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = manager.GetByIDBL(id);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = manager.GetByIDBL(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult CreateMessage(Message message)
        {
            return View();
        }
    }
}