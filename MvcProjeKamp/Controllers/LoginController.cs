using BusinessLayer.Concrete;
using CaptchaMvc.HtmlHelpers;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;
using System.Web.Security;


namespace MvcProjeKamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager adm = new AdminManager(new EFAdminDal());
        WriterLoginManager wlm = new WriterLoginManager(new EFWriterDal());
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
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {

            if (this.IsCaptchaValid("Captcha is not valid"))
            {

                var writeruserinfo = wlm.GetWriter(p.WriterMail, p.WriterPassword);
                if (writeruserinfo != null)
                {
                    FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                    Session["WriterMail"] = writeruserinfo.WriterMail;
                    return RedirectToAction("MyContent", "WriterPanelContent");
                }
                else
                {
                    TempData["error"] = "Hata:Yanlış şifre veya kullanıcı maili";
                    return RedirectToAction("WriterLogin");
                }
            }
            else
            {
                TempData["error"] = "Hata: Doğrulama kodu başarısız";
                return RedirectToAction("WriterLogin");
            }


        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "MainPage");
        }
    }
}