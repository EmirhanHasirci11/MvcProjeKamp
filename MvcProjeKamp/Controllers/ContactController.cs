using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        ContactValidator cv = new ContactValidator();
        Context c = new Context();
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.getByID(id);
            return View(contactValues);
        } 
        public PartialViewResult MessageListMenu()
        {
            ViewBag.DraftMessages = c.Drafts.Where(x => x.SenderMail == "admin@gmail.com"&&x.DraftStatus==true).Count();
            ViewBag.adminMessageCount = cm.GetList().Count();
            ViewBag.senderMessageCount = c.Messages.Where(x => x.SenderMail == "admin@gmail.com").Count();
            ViewBag.recieverMessageCount = c.Messages.Where(x => x.ReceiverMail == "admin@gmail.com").Count();
           
            return PartialView();
        }
    }
}