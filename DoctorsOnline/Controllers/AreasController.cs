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
    public class AreasController : Controller
    {
        private DoctorsOnlineContext db = new DoctorsOnlineContext();

        // GET: /Areas/
        public ActionResult Index()
        {
            return View(db.Areas.ToList());
        }

        // GET: /Areas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // GET: /Areas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Areas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,AreaName")] Area area)
        {
            if (ModelState.IsValid)
            {
                db.Areas.Add(area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(area);
        }

        // GET: /Areas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // POST: /Areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,AreaName")] Area area)
        {
            if (ModelState.IsValid)
            {
                db.Entry(area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(area);
        }

        // GET: /Areas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // POST: /Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Area area = db.Areas.Find(id);
            db.Areas.Remove(area);
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
