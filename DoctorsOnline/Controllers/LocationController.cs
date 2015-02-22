using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoctorsOnline.Models;

namespace DoctorsOnline.Controllers
{
    public class LocationController : Controller
    {
        private DoctorsOnlineContext db = new DoctorsOnlineContext();

        // GET: /Location/
        public ActionResult Index()
        {
            var locations = db.Locations.Include(l => l.Districts).Include(l => l.Divisions).Include(l => l.DoctorsInfo).Include(l => l.Thanas);
            return View(locations.ToList());
        }

        // GET: /Location/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: /Location/Create
        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "DistrictName");
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionName");
            ViewBag.DoctorsInfoId = new SelectList(db.DoctorsInfos, "Id", "DoctorName");
            ViewBag.ThanaId = new SelectList(db.Thanas, "Id", "ThanaName");
            return View();
        }

        // POST: /Location/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,LocationName,DoctorsInfoId,DivisionId,DistrictId,ThanaId")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "DistrictName", location.DistrictId);
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionName", location.DivisionId);
            ViewBag.DoctorsInfoId = new SelectList(db.DoctorsInfos, "Id", "DoctorName", location.DoctorsInfoId);
            ViewBag.ThanaId = new SelectList(db.Thanas, "Id", "ThanaName", location.ThanaId);
            return View(location);
        }

        // GET: /Location/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "DistrictName", location.DistrictId);
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionName", location.DivisionId);
            ViewBag.DoctorsInfoId = new SelectList(db.DoctorsInfos, "Id", "DoctorName", location.DoctorsInfoId);
            ViewBag.ThanaId = new SelectList(db.Thanas, "Id", "ThanaName", location.ThanaId);
            return View(location);
        }

        // POST: /Location/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,LocationName,DoctorsInfoId,DivisionId,DistrictId,ThanaId")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "DistrictName", location.DistrictId);
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionName", location.DivisionId);
            ViewBag.DoctorsInfoId = new SelectList(db.DoctorsInfos, "Id", "DoctorName", location.DoctorsInfoId);
            ViewBag.ThanaId = new SelectList(db.Thanas, "Id", "ThanaName", location.ThanaId);
            return View(location);
        }

        // GET: /Location/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: /Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
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
