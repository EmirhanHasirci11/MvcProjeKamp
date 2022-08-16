using DataAccessLayer.Concrete;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class IstatistikController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            ViewBag.SumCat = c.Categories.Count();
            ViewBag.SumHeadingYazilim = c.Headings.Where(x => x.Category.CategoryName == "Yazılım").Count();
            ViewBag.SumWritersContainsA = c.Writers.Where(x => x.WriterName.Contains("a")).Count();
            ViewBag.TopOneCategoryName = c.Headings.Max(x => x.Category.CategoryName);
            ViewBag.CatDifferenceBetweenTrueAndFalse = c.Categories.Where(x => x.CategoryStatus == true).Count() - c.Categories.Where(x => x.CategoryStatus == false).Count();


            return View();
        }
    }
}