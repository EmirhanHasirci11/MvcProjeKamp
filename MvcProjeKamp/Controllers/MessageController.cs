using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class MessageController : Controller
    {
        Context c = new Context();
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator mv = new MessageValidator();
        DraftManager dm = new DraftManager(new EFDraftDal());
        public ActionResult Inbox()
        {
            ViewBag.messageStatusIsFalse = c.Messages.Where(x => x.MessageStatus == false&&x.ReceiverMail=="admin@gmail.com").Count();
            var messageValues = mm.GetListInbox();
            return View(messageValues);
        }
        public ActionResult Sendbox()
        {
            var senderValues = mm.GetListSendbox();
            return View(senderValues);
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
            mm.DraftToMessage(d,value);
            
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

                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                  ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                TempData["ModelState"] = ModelState;
            }
            return RedirectToAction("NewMessage");
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
        public ActionResult SetRead(int id)
        {
            mm.MessageReaded(id);
            return RedirectToAction("Inbox");
        }
    }
}
