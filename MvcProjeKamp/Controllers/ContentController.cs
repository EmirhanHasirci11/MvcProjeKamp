using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContent(string p)
        {
            var values = cm.GetList();
            if (p != null)
            {
                values = cm.GetList(p);
                return View(values);
            }
            else
            {
                return View(values);
            }
        }
        public ActionResult GetContentByHeading(int id)
        {
            var contentValue = cm.GetListById(id);
            return View(contentValue);
        }
    }
}