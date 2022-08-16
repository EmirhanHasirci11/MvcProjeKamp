using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKamp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    [AllowAnonymous]
    public class CallenderController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        Context c = new Context();
        // GET: Callender
        [HttpGet]
        public ActionResult Index()
        {
            return View(new CallenderEntities());
        }
        public JsonResult AllHeading(DateTime start, DateTime end)
        {
            var viewModel = new CallenderEntities();
            var events = new List<CallenderEntities>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-14);

            foreach (var item in hm.GetList())
            {
                events.Add(new CallenderEntities()
                {
                    title = item.HeadingName,
                    start = item.HeadingDate,
                    end = item.HeadingDate.AddDays(-14),
                    allDay = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
                
            }
            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }
            
        
    } 
}