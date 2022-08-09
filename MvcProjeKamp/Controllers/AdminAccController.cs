using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class AdminAccController : Controller
    {
        AdminManager adm = new AdminManager(new EFAdminDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            string salt = adm.AdminGenerateSalt();
            adm.AdminHasher(p,salt);
            
            adm.AdminAdd(p);
            return RedirectToAction("Index");
        }

    }
}