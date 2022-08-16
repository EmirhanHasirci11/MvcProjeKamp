using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        WriterLoginManager wlm = new WriterLoginManager(new EFWriterDal());
        public ActionResult MyContent(string p)
        {
            Context c = new Context();

            p = (string)Session["WriterMail"];
            var writeridinfo = wlm.GetID(p);

            var contentValue = cm.GetListByWriter(writeridinfo);
            return View(contentValue);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string s = (string)Session["WriterMail"];
            var writeridinfo = wlm.GetID(s);
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
    }
}