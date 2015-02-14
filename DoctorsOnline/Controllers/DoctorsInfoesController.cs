using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoctorsOnline.Models;
using Model;

namespace DoctorsOnline.Controllers
{
    public class DoctorsInfoesController : Controller
    {
        private DoctorsOnlineContext db = new DoctorsOnlineContext();

        // GET: DoctorsInfoes
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.SpecialistSortParm = sortOrder == "Specialist" ? "spe_des" : "Specialist";

            var doctors = from s in db.DoctorsInfos
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                doctors = doctors.Where(s => s.DoctorName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc": doctors.OrderByDescending(s => s.DoctorName);
                    break;

                case "Date": doctors.OrderBy(s => s.VisitStartTime);
                    break;

                case "date_desc": doctors.OrderByDescending(s => s.VisitStartTime);
                    break;

                case "Specialist": doctors.OrderBy(s => s.Specialist);
                    break;

                case "spe_des": doctors.OrderByDescending(s => s.Specialist);
                    break;

                default:
                    doctors.OrderBy(s => s.DoctorName);
                    break;
            }
            return View(doctors.ToList());

           // return View(db.DoctorsInfos.ToList());
        }

        // GET: DoctorsInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorsInfo doctorsInfo = db.DoctorsInfos.Find(id);
            if (doctorsInfo == null)
            {
                return HttpNotFound();
            }
            return View(doctorsInfo);
        }

        // GET: DoctorsInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorsInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DoctorName,Qualification,Specialist,Gender,VisitStartTime,VisitEndTime")] DoctorsInfo doctorsInfo)
        {
            if (ModelState.IsValid)
            {
                db.DoctorsInfos.Add(doctorsInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctorsInfo);
        }

        // GET: DoctorsInfoes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorsInfo doctorsInfo = db.DoctorsInfos.Find(id);
            if (doctorsInfo == null)
            {
                return HttpNotFound();
            }
            return View(doctorsInfo);
        }

        // POST: DoctorsInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DoctorName,Qualification,Specialist,Gender,VisitingTime")] DoctorsInfo doctorsInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorsInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctorsInfo);
        }

        // GET: DoctorsInfoes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorsInfo doctorsInfo = db.DoctorsInfos.Find(id);
            if (doctorsInfo == null)
            {
                return HttpNotFound();
            }
            return View(doctorsInfo);
        }

        // POST: DoctorsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorsInfo doctorsInfo = db.DoctorsInfos.Find(id);
            db.DoctorsInfos.Remove(doctorsInfo);
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
