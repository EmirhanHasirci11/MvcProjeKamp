using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EFAdminDal());
        public ActionResult Index()
        {
            string adminUsername = (string)Session["AdminUserName"];
            string adminRole = adm.AdminRole(adminUsername);
            ViewBag.role = adminRole;
            if (adminRole == "B")
            {
                var adminValues = adm.GetListAdmins();
                return View(adminValues);
            }
            else
            {

                var adminValues = adm.GetListAdminsByRole(adminRole);
                return View(adminValues);
            }
        }
        public ActionResult DeleteAdmin(int id)
        {
            string adminUsername = (string)Session["AdminUserName"];
            string adminRole = adm.AdminRole(adminUsername);
            var getAdmin = adm.GetById(id);
            if (adminRole == getAdmin.AdminRole || adminRole == "B")
            {
                adm.AdminDelete(getAdmin);

                return RedirectToAction("Index");
            }
            else
            {

                return RedirectToAction("Index");

            }
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            string adminUsername = (string)Session["AdminUserName"];
            string adminRole = adm.AdminRole(adminUsername);
            var getAdmin = adm.GetById(id);
            if (adminRole == getAdmin.AdminRole || adminRole == "B")
            {

                List<SelectListItem> roleValues = (from x in adm.GetListAdmins()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.AdminRole,
                                                       Value = x.AdminRole

                                                   }).Distinct().ToList();
                ViewBag.roles = roleValues;


                return View(getAdmin);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {

            adm.AdminUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult AddAdmin()
        {
            return RedirectToAction("Index", "AdminAcc");
        }
    }
}