using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKamp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class ChartController : Controller
    {
        SkillsManager sm = new SkillsManager(new EFSkillsDal());
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Chart2()
        {
            return View();
        }
        public ActionResult Chart3()
        {
            return View();
        }
        public ActionResult WriterHeading()
        {
            return Json(WriterHeadingList(), JsonRequestBehavior.AllowGet);

        }
        public ActionResult headingContent()
        {
            return Json(HeadingContentList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<WritersHeadings> WriterHeadingList()
        {
            List<WritersHeadings> wh = new List<WritersHeadings>();
            wh = c.Writers.Select(x => new WritersHeadings
            {
                WriterName = x.WriterName,
                TotalCount = x.Headings.Count()
            }).ToList();
            return wh;
        }
        public List<HeadingContentCount> HeadingContentList()
        {
            List<HeadingContentCount> hcc = new List<HeadingContentCount>();
            hcc = c.Headings.Select(x => new HeadingContentCount
            {
                HeadingName = x.HeadingName,
                TotalContent = x.Contents.Count()
            }).ToList();
            return hcc;
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 20
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 15
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Anime",
                CategoryCount = 40
            });
            return ct;
        }

    }
}