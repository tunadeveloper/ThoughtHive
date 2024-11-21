using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        MessageValidator validator = new MessageValidator();
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
           ValidationResult results = validator.Validate(message);
            if (results.IsValid)
            {
                message.MessageDate = DateTime.Now;
                manager.MessageAddBL(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}