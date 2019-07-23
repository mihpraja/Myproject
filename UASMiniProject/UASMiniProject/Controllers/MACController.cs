using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UASMiniProject.Models;

namespace UASMiniProject.Controllers
{
    public class MACController : Controller
    {
        private UAScontextss db = new UAScontextss();
        // GET: MAC
        public ActionResult Index()
        {
            if (Session["Login_id"] == null)
            {

                return RedirectToAction("Login", "Users");
            }
            else
            {
                return View();
            }
        }
        //View applications for a specific program
        public ActionResult ViewApp(string search)
        {
            if (Session["Login_id"] != null)
            {
                return View(db.ApplicationForms.Where(x => x.Scheduled_Program_Id.ToString() == search).ToList());
            }
            else
            {

                return RedirectToAction("Login", "Users");
            }

        }

        public ActionResult Accept(int? id)
        {
            if (Session["Login_id"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ApplicationForm applicant = db.ApplicationForms.Find(id);
                if (applicant == null)
                {
                    return HttpNotFound();
                }
                return View(applicant);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        // POST: Applicant_174864/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Accept([Bind(Include = "Application_Id, Full_Name, Date_Of_Birth, Highest_Qualification, Marks_Obtained, Goals, Email_Id, Scheduled_Program_Id, Status, Date_Of_Interview")] ApplicationForm applicant)
        {
            if (Session["Login_id"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(applicant).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("StatusChange", "MAC");
                }
                return View(applicant);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        public ActionResult StatusChange()
        {
            if (Session["Login_id"] != null)
            {
                var model = db.ApplicationForms.Where(h => h.Status == "Accept" || h.Status == "Reject" || h.Status == "Applied");

                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }


        //If accepted, fill in the scheduled date for an interview of the applicant before confirming the applicant to take the program.
        public ActionResult Interview()
        {
            if (Session["Login_id"] != null)
            {
                var model = db.ApplicationForms.Where(h => h.Status == "Accept");

                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        //After the interview, update the status of the application to Confirmed/Rejected


        public ActionResult ConfirmedOrRejected(int? id)
        {
            if (Session["Login_id"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ApplicationForm applicant = db.ApplicationForms.Find(id);
                if (applicant == null)
                {
                    return HttpNotFound();
                }
                return View(applicant);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        // POST: Applicant_174864/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmedOrRejected([Bind(Include = "Application_Id, Full_Name, Date_Of_Birth, Highest_Qualification, Marks_Obtained, Goals, Email_Id, Scheduled_Program_Id, Status, Date_Of_Interview")] ApplicationForm applicant)
        {
            if (Session["Login_id"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(applicant).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("DisplayInterview", "MAC");
                }
                return View(applicant);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        public ActionResult DisplayInterview()
        {
            if (Session["Login_id"] != null)
            {
                var model = db.ApplicationForms.Where(h => h.Status == "Confirmed" || h.Status == "Reject");

                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        public ActionResult Reject(int? id)
        {
            if (Session["Login_id"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ApplicationForm applicant = db.ApplicationForms.Find(id);
                if (applicant == null)
                {
                    return HttpNotFound();
                }
                return View(applicant);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        // POST: Applicant_174864/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reject([Bind(Include = "Application_Id, Full_Name, Date_Of_Birth, Highest_Qualification, Marks_Obtained, Goals, Email_Id, Scheduled_Program_Id, Status, Date_Of_Interview")] ApplicationForm applicant)
        {
            if (Session["Login_id"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(applicant).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("StatusChange", "MAC");
                }
                return View(applicant);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }
    }
}