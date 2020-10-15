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
    public class PatientsController : Controller
    {      

        // GET: Patient
        public ActionResult Index()
        {
            IBL bl = new BLImplement();
            var lst = new List<PatientViewModel> ();
            foreach (var item in bl.getAllPatients())
            {
                lst.Add(new PatientViewModel(item));
            }
            return View(lst);
        }

        // GET: Patient/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            Patient patient = bl.getAllPatients().FirstOrDefault(x=>x.Id==id);
            PatientViewModel patientViewModel = new PatientViewModel(patient);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patientViewModel);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            var pvm =new PatientViewModel();
            return View(pvm);
        }

        // POST: Patient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PatientViewModel patientViewModel)
        {
           
            if (ModelState.IsValid)
            {
                Patient patient = new Patient()
                {
                    Name = patientViewModel.Name,
                  //  Prescriptions = bl.allPrescriptionFromPatient(patientViewModel).Select(p => p.Id).ToList();
            };
                IBL bl = new BLImplement();
                bl.addPatient(patient);
                return RedirectToAction("Index");
            }

            return View(patientViewModel);
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            Patient patient = new Patient();//bl.getPtient(id);
            PatientViewModel patientViewModel = new PatientViewModel()
            {
                Name = patient.Name,
                Prescriptions = bl.allPrescriptionFromPatient(patient).Select(p => p.Id).ToList()
        };
            if (patientViewModel == null)
            {
                return HttpNotFound();
            }
            return View(patientViewModel);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
      /*  public ActionResult Edit([Bind(Include = "Id,Name")] PatientViewModel patientViewModel)
        {
            IBL bl = new BLImplement();
            try
            {
                bl.ExsistPtient(Id);
            }
            catch (Exception ex)
            {
                ViewBag.Message = String.Format(ex.Message);
                return View("LogInPatient");// אחרי שקופצת השגיאה החזרתי בחזרה לview ממנו הגיעה השגיאה

            }
        }*/


        // GET: Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientViewModel patientViewModel = new PatientViewModel();//db.PatientViewModels.Find(id);
            if (patientViewModel == null)
            {
                return HttpNotFound();
            }
            return View(patientViewModel);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IBL bl = new BLImplement();
            Patient patient = new Patient();//db.Patient.Find(id);
            bl.deletePatient(patient);// db.PatientViewModels.Remove(patientViewModel);
            return RedirectToAction("Index");
        }

      /*  protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}