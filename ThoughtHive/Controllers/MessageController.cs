﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
            var values = manager.GetListBL();
            return View(values);
        }
    }
}