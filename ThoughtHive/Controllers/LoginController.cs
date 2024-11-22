using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ThoughtHive.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        AdminManager manager = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var value = manager.GetAdmin(admin.AdminUserName, admin.AdminPassword);
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.AdminUserName, false);
                Session["AdminUserName"] = value.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return View();
            }
        }
    }
}