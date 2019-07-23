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
    public class ProgramsScheduledController : Controller
    {
        private UAScontextss db = new UAScontextss();

        // GET: ProgramsScheduled
        public ActionResult Index()
        {
            return View(db.ProgramsScheduleds.ToList());
        }

        // GET: ProgramsScheduled/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramsScheduled programsScheduled = db.ProgramsScheduleds.Find(id);
            if (programsScheduled == null)
            {
                return HttpNotFound();
            }
            return View(programsScheduled);
        }

        // GET: ProgramsScheduled/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgramsScheduled/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Scheduled_Program_Id,Program_Name,Location,Start_Date,End_Date,Sessions_Per_Week,DummyID")] ProgramsScheduled programsScheduled)
        {
            if (ModelState.IsValid)
            {
                db.ProgramsScheduleds.Add(programsScheduled);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(programsScheduled);
        }

        // GET: ProgramsScheduled/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramsScheduled programsScheduled = db.ProgramsScheduleds.Find(id);
            if (programsScheduled == null)
            {
                return HttpNotFound();
            }
            return View(programsScheduled);
        }

        // POST: ProgramsScheduled/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Scheduled_Program_Id,Program_Name,Location,Start_Date,End_Date,Sessions_Per_Week,DummyID")] ProgramsScheduled programsScheduled)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programsScheduled).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programsScheduled);
        }

        // GET: ProgramsScheduled/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramsScheduled programsScheduled = db.ProgramsScheduleds.Find(id);
            if (programsScheduled == null)
            {
                return HttpNotFound();
            }
            return View(programsScheduled);
        }

        // POST: ProgramsScheduled/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgramsScheduled programsScheduled = db.ProgramsScheduleds.Find(id);
            db.ProgramsScheduleds.Remove(programsScheduled);
            db.SaveChanges();
            return RedirectToAction("Index");
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
