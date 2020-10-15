﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrescriptionBE;
using PrescriptionBL;
using PrescriptionUI.Data;
using PrescriptionUI.Models;

namespace PrescriptionUI.Controllers
{
    public class DoctorsController : Controller
    {

        // GET: Doctors
        public ActionResult Index()
        {
            IBL bl = new BLImplement();
            return View(bl.getAllDoctors().ToList());
        }

        // GET: Doctors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            Doctor doctor = bl.getAllDoctors().ToList().FindAll(x => x.Id == id).FirstOrDefault();
            if (doctor == null)
            {
                return HttpNotFound();
            }
            DoctorViewModel dvm = new DoctorViewModel(doctor);
            return View(dvm);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            var dvm = new DoctorViewModel();
            return View(dvm);
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Special,LicenseExpirationDate")] DoctorViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                IBL bl = new BLImplement();
                Doctor doctor = new Doctor()
                {
                    Name = dvm.Name,
                    LicenseExpirationDate = Convert.ToDateTime(dvm.LicenseExpirationDate),
                    Special = dvm.Special
                };
                bl.addDoctor(doctor);
                return RedirectToAction("Index");
            }
            return View(dvm);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            Doctor doctor = bl.getAllDoctors().ToList().FindAll(x => x.Id == id).FirstOrDefault();
            if (doctor == null)
            {
                return HttpNotFound();
            }
            DoctorViewModel dvm = new DoctorViewModel(doctor);
            return View(dvm);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Special,LicenseExpirationDate")] DoctorViewModel doctorViewModel)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(doctorViewModel).State = EntityState.Modified;
                return RedirectToAction("Index");
            }
            return View(doctorViewModel);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            Doctor doctor = bl.getAllDoctors().ToList().FindAll(x => x.Id == id).FirstOrDefault();
            if (doctor == null)
            {
                return HttpNotFound();
            }
            DoctorViewModel dvm = new DoctorViewModel(doctor);
            return View(dvm);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            IBL bl = new BLImplement();
            Doctor doctor = bl.getAllDoctors().ToList().FindAll(x => x.Id == id).FirstOrDefault();
            bl.deleteDoctor(doctor);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}