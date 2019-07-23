using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using UASMiniProject.Models;



namespace UASMiniProject.Controllers
{
    public class ParticipantController : Controller
    {
        private UAScontextss db = new UAScontextss();
        // GET: Participant
        //List of programs scheduled to commence in a given time period
        public ActionResult TimeTable()
        {
            if (Session["Login_id"] != null)
            {

                var offer_Schedule = db.Offer_Scheduled.Include(o => o.ProgramsScheduled).Include(o => o.ProgramsOffered);
                return View(offer_Schedule.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }
    }
}