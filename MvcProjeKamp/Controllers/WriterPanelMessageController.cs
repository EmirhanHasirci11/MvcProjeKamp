using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        Context c = new Context();
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator mv = new MessageValidator();
        DraftManager dm = new DraftManager(new EFDraftDal());
        WriterLoginManager vlm = new WriterLoginManager(new EFWriterDal());
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            int id = vlm.GetID(p);
            ViewBag.messageStatusIsFalse = mm.GetUnreadMessage(p);
            var messageValues = mm.GetListInbox(p);
            return View(messageValues);
        }
        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["WriterMail"];
            ViewBag.DraftMessages = c.Drafts.Where(x => x.SenderMail == p && x.DraftStatus == true).Count();
            ViewBag.senderMessageCount = c.Messages.Where(x => x.SenderMail == p).Count();
            ViewBag.recieverMessageCount = c.Messages.Where(x => x.ReceiverMail == p).Count();
            return PartialView();
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            int id = vlm.GetID(p);
            var senderValues = mm.GetListSendbox(p);
            return View(senderValues);
        }
        public ActionResult GetInboxDetails(int id)
        {
            ViewBag.id = id;
            mm.SetReaded(id);
            var messageValues = mm.GetById(id);
            return View(messageValues);
        }
        public ActionResult GetSendboxDetails(int id)
        {
            var messageValues = mm.GetById(id);
            return View(messageValues);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            if (TempData.ContainsKey("ModelState"))
                ModelState.Merge((ModelStateDictionary)TempData["ModelState"]);
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ActionName("DraftMessage")]
        public ActionResult NewMessage(Draft d)
        {

            var value = new Message();
            mm.DraftToMessage(d, value);

            return NewMessage(value);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ActionName("SendMessage")]

        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = mv.Validate(p);
            if (results.IsValid)
            {
                string mail = (string)Session["WriterMail"];
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p, mail);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                TempData["ModelState"] = ModelState;
            }
            return RedirectToAction("NewMessage");

        }
    }
}