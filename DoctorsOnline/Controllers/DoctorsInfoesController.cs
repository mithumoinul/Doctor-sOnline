using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using DoctorsOnline.Models;

namespace DoctorsOnline.Controllers
{
    public class DoctorsInfoesController : Controller
    {
        private DoctorsOnlineContext db = new DoctorsOnlineContext();

        // GET: /DoctorsInfoes/
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.SpecialistSortParm = sortOrder == "Specialist" ? "spe_des" : "Specialist";

            var doctorsinfos = db.DoctorsInfos.Include(d => d.Department).Include(d => d.Hospital);
            
            if (!String.IsNullOrEmpty(searchString))
            {

                doctorsinfos = doctorsinfos.Where(s => s.DoctorName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc": doctorsinfos.OrderByDescending(s => s.DoctorName);
                    break;

                case "Date": doctorsinfos.OrderBy(s => s.VisitStartTime);
                    break;

                case "date_desc": doctorsinfos.OrderByDescending(s => s.VisitStartTime);
                    break;

                case "Specialist": doctorsinfos.OrderBy(s => s.Specialist);
                    break;

                case "spe_des": doctorsinfos.OrderByDescending(s => s.Specialist);
                    break;

                default:
                    doctorsinfos.OrderBy(s => s.DoctorName);
                    break;
            }

            
            return View(doctorsinfos.ToList());
        }

        // GET: /DoctorsInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorsInfo doctorsinfo = db.DoctorsInfos.Find(id);
            if (doctorsinfo == null)
            {
                return HttpNotFound();
            }
            return View(doctorsinfo);
        }

        // GET: /DoctorsInfoes/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName");
            ViewBag.HospitalId = new SelectList(db.Hospitals, "Id", "HospitalName");
            return View();
        }

        // POST: /DoctorsInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DoctorName,Qualification,Specialist,Gender,VisitStartTime,VisitEndTime,HospitalId,DepartmentId")] DoctorsInfo doctorsinfo)
        {
            if (ModelState.IsValid)
            {
                db.DoctorsInfos.Add(doctorsinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", doctorsinfo.DepartmentId);
            ViewBag.HospitalId = new SelectList(db.Hospitals, "Id", "HospitalName", doctorsinfo.HospitalId);
            return View(doctorsinfo);
        }

        // GET: /DoctorsInfoes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorsInfo doctorsinfo = db.DoctorsInfos.Find(id);
            if (doctorsinfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", doctorsinfo.DepartmentId);
            ViewBag.HospitalId = new SelectList(db.Hospitals, "Id", "HospitalName", doctorsinfo.HospitalId);
            return View(doctorsinfo);
        }

        // POST: /DoctorsInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DoctorName,Qualification,Specialist,Gender,VisitStartTime,VisitEndTime,HospitalId,DepartmentId")] DoctorsInfo doctorsinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorsinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", doctorsinfo.DepartmentId);
            ViewBag.HospitalId = new SelectList(db.Hospitals, "Id", "HospitalName", doctorsinfo.HospitalId);
            return View(doctorsinfo);
        }

        // GET: /DoctorsInfoes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorsInfo doctorsinfo = db.DoctorsInfos.Find(id);
            if (doctorsinfo == null)
            {
                return HttpNotFound();
            }
            return View(doctorsinfo);
        }

        // POST: /DoctorsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorsInfo doctorsinfo = db.DoctorsInfos.Find(id);
            db.DoctorsInfos.Remove(doctorsinfo);
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
