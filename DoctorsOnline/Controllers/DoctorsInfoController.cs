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
    public class DoctorsInfoController : Controller
    {
        private DoctorsOnlineContext db = new DoctorsOnlineContext();

        // GET: /DoctorsInfo/
        public ActionResult Index()
        {
            return View(db.DoctorsInfos.ToList());
        }

        // GET: /DoctorsInfo/Details/5
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

        // GET: /DoctorsInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DoctorsInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DoctorName,Qualification,Designation,Specialist,Experience,Gender,Phone,Email,DepartmentName,HospitalName,VisitStartTime,VisitEndTime")] DoctorsInfo doctorsinfo)
        {
            if (ModelState.IsValid)
            {
                db.DoctorsInfos.Add(doctorsinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctorsinfo);
        }

        // GET: /DoctorsInfo/Edit/5
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
            return View(doctorsinfo);
        }

        // POST: /DoctorsInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DoctorName,Qualification,Designation,Specialist,Experience,Gender,Phone,Email,VisitStartTime,VisitEndTime")] DoctorsInfo doctorsinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorsinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctorsinfo);
        }

        // GET: /DoctorsInfo/Delete/5
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

        // POST: /DoctorsInfo/Delete/5
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
