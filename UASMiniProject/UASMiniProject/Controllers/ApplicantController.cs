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
    public class ApplicantController : Controller
    {
        private UAScontextss db = new UAScontextss();

        // GET: Applicant
        public ActionResult Index()
        {
            return View(db.ApplicationForms.ToList());
        }

        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        //Registration
        public ActionResult Register(ApplicationForm register)

        {
            if (register == null)
            {
                ViewBag.Message = "Please enter the Data";
            }
            if (ModelState.IsValid)
            {
                db.ApplicationForms.Add(register);
                db.SaveChanges();
                ViewBag.Message = "Sucessfully Added";
                return RedirectToAction("DisplayApplicant");
            }


            return View(register);
        }

        public ActionResult DisplayApplicant()
        {
            return View();
        }

        public ActionResult StatusFinal(string search)
        {
            var model = db.ApplicationForms.Where(s => s.Email_Id == search);
            return View(model);
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
//        // GET: Applicant/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Applicant/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Application_Id,Full_Name,Date_Of_Birth,Highest_Qualification,Marks_Obtained,Goals,Email_Id,Scheduled_Program_Id,Status,Date_Of_Interview")] ApplicationForm applicationForm)
//        {
//            if (ModelState.IsValid)
//            {
//                db.ApplicationForms.Add(applicationForm);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(applicationForm);
//        }

//        // GET: Applicant/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ApplicationForm applicationForm = db.ApplicationForms.Find(id);
//            if (applicationForm == null)
//            {
//                return HttpNotFound();
//            }
//            return View(applicationForm);
//        }

//        // POST: Applicant/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Application_Id,Full_Name,Date_Of_Birth,Highest_Qualification,Marks_Obtained,Goals,Email_Id,Scheduled_Program_Id,Status,Date_Of_Interview")] ApplicationForm applicationForm)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(applicationForm).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(applicationForm);
//        }

//        // GET: Applicant/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ApplicationForm applicationForm = db.ApplicationForms.Find(id);
//            if (applicationForm == null)
//            {
//                return HttpNotFound();
//            }
//            return View(applicationForm);
//        }

//        // POST: Applicant/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            ApplicationForm applicationForm = db.ApplicationForms.Find(id);
//            db.ApplicationForms.Remove(applicationForm);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
