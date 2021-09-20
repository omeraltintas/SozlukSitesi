using BusinessLayer.Concrete;
using DAL.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager am = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminvalues = am.GetList();
            return View(adminvalues);
        }
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            am.AdminAdd(admin);
            return RedirectToAction("Index");
        }
        public ActionResult EditAdmin(int id)
        {
            var admin = am.GetById(id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            am.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}