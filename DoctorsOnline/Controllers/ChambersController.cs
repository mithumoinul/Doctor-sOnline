using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoctorsOnline.Models;

namespace DoctorsOnline.Controllers
{
    public class ChambersController : Controller
    {
        private DoctorsOnlineContext db = new DoctorsOnlineContext();

        // GET: /Chambers/
        public async Task<ActionResult> Index()
        {
            return View(await db.Chambers.ToListAsync());
        }

        // GET: /Chambers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamber chamber = await db.Chambers.FindAsync(id);
            if (chamber == null)
            {
                return HttpNotFound();
            }
            return View(chamber);
        }

        // GET: /Chambers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Chambers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,ChamberName,Phone,Email")] Chamber chamber)
        {
            if (ModelState.IsValid)
            {
                db.Chambers.Add(chamber);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(chamber);
        }

        // GET: /Chambers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamber chamber = await db.Chambers.FindAsync(id);
            if (chamber == null)
            {
                return HttpNotFound();
            }
            return View(chamber);
        }

        // POST: /Chambers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,ChamberName,Phone,Email")] Chamber chamber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamber).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(chamber);
        }

        // GET: /Chambers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamber chamber = await db.Chambers.FindAsync(id);
            if (chamber == null)
            {
                return HttpNotFound();
            }
            return View(chamber);
        }

        // POST: /Chambers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Chamber chamber = await db.Chambers.FindAsync(id);
            db.Chambers.Remove(chamber);
            await db.SaveChangesAsync();
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
