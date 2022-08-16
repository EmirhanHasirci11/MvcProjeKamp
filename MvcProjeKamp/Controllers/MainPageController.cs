using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    [AllowAnonymous]
    public class MainPageController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            
            return View(headingList);
        }
        public PartialViewResult Index(int id = 1)
        {
            var contentList = cm.GetListByHeading(id);
            int countOfContent = cm.CountOfContentByHeadingId(id);
            if (countOfContent != 0)
            {

                ViewBag.headerName = contentList.Select(x => x.Heading.HeadingName).FirstOrDefault();
            }
            else
            {
                ViewBag.headerName = "Aranan başlığa göre içerik bulunamadı";
            }
            return PartialView(contentList);
        }
        [HttpGet]
        public ActionResult HomePage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HomePage(Writer w)
        {
            w.WriterTitle = "Yazar";
            w.WriterStatus = true;
            w.WriterImage = "https://w7.pngwing.com/pngs/315/234/png-transparent-graphy-young-blond-man-men-s-health-male-man.png";
            w.WriterAbout = "Yeni Yazar";
            wm.WriterAdd(w);
            return RedirectToAction("WriterLogin", "Login");

        }


    }
}