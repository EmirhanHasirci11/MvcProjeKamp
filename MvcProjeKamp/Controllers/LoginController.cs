using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Web.Security;

namespace MvcProjeKamp.Controllers
{
    public class LoginController : Controller
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
            
            var accountValues = adm.AdminUsername(p);
            if (accountValues != null)
            {
                bool result = adm.AdminEncryption(p, accountValues);


                if (result)
                {
                    FormsAuthentication.SetAuthCookie(accountValues.AdminUserName, false);
                    Session["AdminUserName"] = accountValues.AdminUserName;
                    return RedirectToAction("Index", "AdminCategory");
                }
                else
                {
                    TempData["ErrorMessage"] = "Giriş başarısız yanlış kullanıcı adı veya şifre";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}