using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using DoctorsOnline.Models;

namespace DoctorsOnline.Controllers
{
    public class AppointmentsController : Controller
    {
        private DoctorsOnlineContext db = new DoctorsOnlineContext();

        // GET: /Appointments/
        public async Task<ActionResult> Index()
        {
            var appointments = db.Appointments.Include(a => a.Chamber).Include(a => a.Hospital);
            return View(await appointments.ToListAsync());
        }

        // GET: /Appointments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = await db.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: /Appointments/Create
        public ActionResult Create()
        {
            ViewBag.ChamberId = new SelectList(db.Chambers, "Id", "ChamberName");
            ViewBag.HospitalId = new SelectList(db.Hospitals, "Id", "HospitalName");
            return View();
        }

        // POST: /Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,AppointmentNo,AppointmentDate,AppointmentTime,IsActive,HospitalId,ChamberId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ChamberId = new SelectList(db.Chambers, "Id", "ChamberName", appointment.ChamberId);
            ViewBag.HospitalId = new SelectList(db.Hospitals, "Id", "HospitalName", appointment.HospitalId);
            return View(appointment);
        }

        // GET: /Appointments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = await db.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChamberId = new SelectList(db.Chambers, "Id", "ChamberName", appointment.ChamberId);
            ViewBag.HospitalId = new SelectList(db.Hospitals, "Id", "HospitalName", appointment.HospitalId);
            return View(appointment);
        }

        // POST: /Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,AppointmentNo,AppointmentDate,AppointmentTime,IsActive,HospitalId,ChamberId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ChamberId = new SelectList(db.Chambers, "Id", "ChamberName", appointment.ChamberId);
            ViewBag.HospitalId = new SelectList(db.Hospitals, "Id", "HospitalName", appointment.HospitalId);
            return View(appointment);
        }

        // GET: /Appointments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = await db.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: /Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Appointment appointment = await db.Appointments.FindAsync(id);
            db.Appointments.Remove(appointment);
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
