using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UASMiniProject.Models;
using System.Data.Entity;


namespace UASMiniProject.Controllers
{
    public class Offer_ScheduleController : Controller
    {
        private UAScontextss db = new UAScontextss();
        // GET: Offer_Schedule
        public ActionResult Index()
        {
            var offer_Schedule = db.Offer_Scheduled.Include(o => o.ProgramsScheduled).Include(o => o.ProgramsOffered);
            return View(offer_Schedule.ToList());
        }
    }
}