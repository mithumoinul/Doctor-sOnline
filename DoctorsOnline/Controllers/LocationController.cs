using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using DoctorsOnline.Models;
using Microsoft.Ajax.Utilities;

namespace DoctorsOnline.Controllers
{
    public class LocationController : Controller
    {
        private ILocationRepository _repository;

        public LocationController()
            : this(new LocationRepository())
        {

        }

        public LocationController(ILocationRepository repository)
        {
            _repository = repository;
        }
        //
        // GET: /Location/
        public ActionResult Index()
        {
            LocationModel model = new LocationModel();
            model.AvailableDivisions.Add(new SelectListItem{Text = "--Select Items--",Value = "Selects Item"});
            var divisions = _repository.GetAllDivisions();
            foreach (var division in divisions)
            {
                model.AvailableDivisions.Add(new SelectListItem()
                {
                    Text = division.DivisionName,
                    Value = division.DivisionId.ToString()
                });
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult GetAllDistrictsByDivisionId(string divisionId)
        {
            if (String.IsNullOrEmpty(divisionId))
            {
                throw new ArgumentNullException(divisionId);
            }
            int id = 0;
            bool isValid = Int32.TryParse(divisionId, out id);
            var district = _repository.GetAllDistrictsByDivisionId(id);
            var result = (from d in district
                select new
                {
                    Id = d.Id,
                    //divisionId = d.Id,
                    DistrictName = d.DistrictName
                }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetAllThanasByDistrictId(string districtId)
        {
            if (String.IsNullOrEmpty(districtId))
            {
                throw new ArgumentNullException(districtId);
            }
            int tId = 0;
            bool isValid = Int32.TryParse(districtId, out tId);
            var thana = _repository.GetAllThanasByDistrictId(tId);
            var result = (from t in thana
                select new
                {
                    thanaId = t.Id,
                    thanaName = t.ThanaName
                }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }





        ////
        //// GET: /Location/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /Location/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Location/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Location/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Location/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Location/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Location/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
