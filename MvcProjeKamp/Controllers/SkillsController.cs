using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class SkillsController : Controller
    {
        SkillsManager sm = new SkillsManager(new EFSkillsDal());
        public ActionResult Index()
        {
            var skillValues = sm.GetList();
            return View(skillValues);
        }
        public ActionResult AdminSkillList()
        {
            var values = sm.GetListAll();
            return View(values);
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var skillValues = sm.GetById(id);
            return View(skillValues);
        }
        [HttpPost]
        public ActionResult EditSkill(Skill p)
        {
            sm.SkillUpdate(p);
            return RedirectToAction("AdminSkillList");
        }
        public ActionResult DeleteSkill(int id)
        {
            var SkillValues = sm.GetById(id);
            sm.SkillDelete(SkillValues);
            return RedirectToAction("AdminSkillList");
        }
        [HttpGet]
        public ActionResult AddSkill ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill (Skill p)
        {
            p.SkillStatus = true;
            sm.SkillAdd(p);
            return RedirectToAction("AdminSkillList");
        }
        public PartialViewResult SkillPartial()
        {
            return PartialView();
        }

    }
}