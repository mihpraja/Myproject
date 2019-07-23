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
    public class AdminController : Controller
    {
        private UAScontextss db = new UAScontextss();

        // GET: Admin
        public ActionResult Index()
        {
            if (Session["Login_id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }

        }

        // GET: Admin/Details/5
        public ActionResult DisplayProgram(int? id)
        {
            if (Session["Login_id"] != null)
            {
                return View(db.ProgramsOffereds.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            if (Session["Login_id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(ProgramsOffered programsOffered)
        {
            if (Session["Login_id"] != null)
            {
                db.ProgramsOffereds.Add(programsOffered);
                db.SaveChanges();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Login_id"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ProgramsOffered programsOffered = db.ProgramsOffereds.Find(id);
                if (programsOffered == null)
                {
                    return HttpNotFound();
                }
                return View(programsOffered);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Program_Name,Description,Applicant_Eligibility,Duration,Degree_Certificate_Offered,DummyID_PO")] ProgramsOffered programsOffered)
        {
            if (Session["Login_id"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(programsOffered).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(programsOffered);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Login_id"] != null)
            {
                ProgramsOffered programsOffered = db.ProgramsOffereds.Find(id);
                return View(programsOffered);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        // POST: Admin/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (Session["Login_id"] != null)
            {
                var pro1 = db.ProgramsOffereds.Where(x => x.DummyID_PO == id).FirstOrDefault();
                db.ProgramsOffereds.Remove(pro1);
                db.SaveChanges();
                return RedirectToAction("DisplayProgram");
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        public ActionResult DisplaySchedule()
        {
            if (Session["Login_id"] != null)
            {

                return View(db.ProgramsScheduleds.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        // GET: Program/Create
        public ActionResult CreateSchedule()
        {
            if (Session["Login_id"] != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateSchedule(ProgramsScheduled sch)
        {
            if (Session["Login_id"] != null)
            {
                db.ProgramsScheduleds.Add(sch);
                db.SaveChanges();
                //ViewBag.Title = "Successfully Added";
                return RedirectToAction("DisplaySchedule");
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        public ActionResult EditSchedule(int? id)
        {
            if (Session["Login_id"] != null)
            {
                ProgramsScheduled pro2 = db.ProgramsScheduleds.Find(id);
                if (pro2 == null)
                {
                    return HttpNotFound();
                }
                return View(pro2);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        // POST: ProgramsScheduled/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSchedule([Bind(Include = "DummyID, Scheduled_Program_Id, Program_Name, Location, Start_Date, End_Date, Sessions_Per_Week")] ProgramsScheduled programsScheduled)
        {
            if (Session["Login_id"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(programsScheduled).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("DisplaySchedule");
                }
                return View(programsScheduled);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        // GET: Applicant/Delete/5
        public ActionResult DeleteSchedule(int? id)
        {
            if (Session["Login_id"] != null)
            {
                ProgramsScheduled sch = db.ProgramsScheduleds.Find(id);
                if (sch == null)
                {
                    return HttpNotFound();
                }
                return View(sch);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        // POST: Applicant/Delete/5
        [HttpPost]
        public ActionResult DeleteSchedule(int id)
        {
            if (Session["Login_id"] != null)
            {
                ProgramsScheduled sch = db.ProgramsScheduleds.Find(id);
                db.ProgramsScheduleds.Remove(sch);
                db.SaveChanges();
                return RedirectToAction("DisplaySchedule");
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        ///////////Generate Report///////////////
        public ActionResult Reports()
        {
            if (Session["Login_id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }
        //List of applicants confirmed/ accepted(waiting for interview)/rejected for a scheduled program.
        public ActionResult ShowData(string status)
        {
            if (Session["Login_id"] != null)
            {
                return View(db.ApplicationForms.Where(x => x.Status == status).ToList());
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }
    }
}
