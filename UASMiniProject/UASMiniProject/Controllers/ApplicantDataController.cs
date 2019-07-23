using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UASMiniProject.Models;

namespace UASMiniProject.Controllers
{
    public class ApplicantDataController : Controller
    {
        public UAScontextss db = new UAScontextss();
        // GET: ApplicantData
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Status(string search)
        {
            return View(db.ApplicationForms.Where(x => x.Email_Id.ToString() == search || search == null).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}