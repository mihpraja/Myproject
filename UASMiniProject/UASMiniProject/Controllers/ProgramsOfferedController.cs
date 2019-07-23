using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UASMiniProject.Models;

namespace UASMiniProject.Controllers
{
    public class ProgramsOfferedController : Controller
    {
        private UAScontextss db = new UAScontextss();

        // GET: ProgramsOffered
        public ActionResult Index()
        {
            return View(db.ProgramsOffereds.ToList());
        }

        public ActionResult DisplayOnlineProgram()
        {
            return View();
        }

        public ActionResult DisplayCareerSkills()
        {
            return View();
        }

        public ActionResult Engineering()
        {
            return View();
        }

        public ActionResult HealthScience()
        {
            return View();
        }

        public ActionResult HotelManagement()
        {
            return View();
        }
    }
}
