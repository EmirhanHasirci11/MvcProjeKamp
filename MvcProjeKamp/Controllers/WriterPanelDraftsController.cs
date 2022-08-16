using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Web.Mvc;


namespace MvcProjeKamp.Controllers
{
    public class WriterPanelDraftsController : Controller
    {


        DraftManager dm = new DraftManager(new EFDraftDal());
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator mv = new MessageValidator();

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(Message p)
        {
            Draft d = new Draft();
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            d.DraftDate = p.MessageDate;
            dm.MessageToDraft(p, d);

            return RedirectToAction("Inbox", "WriterPanelMessage");
        }
        public ActionResult DraftMessages()
        {
            var draftValues = dm.GetListInDraft();
            return View(draftValues);
        }
        [HttpGet]
        public ActionResult GetDraftDetails(int id)
        {
            var draftValue = dm.GetById(id);
            return View(draftValue);
        }
        public ActionResult DeleteDraft(int id)
        {
            var deleteValue = dm.GetById(id);
            dm.DraftDelete(deleteValue);
            return RedirectToAction("DraftMessages");
        }
    }
}