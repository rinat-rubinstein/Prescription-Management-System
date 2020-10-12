using System;
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
    public class MedicinesController : Controller
    {

        // GET: Medicines
        public ActionResult Index()
        {
            IBL bl = new BLImplement();
            return View(bl.getAllMedicines());
        }

        // GET: Medicines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            Medicine medicine = bl.getAllMedicines().ToList().FindAll(x => x.Id == id).FirstOrDefault();
            if (medicine == null)
            {
                return HttpNotFound();
            }
            var mvm = new MedicineViewModel(medicine);
            return View(mvm);
        }

        // GET: Medicines/Create
        public ActionResult Create()
        {
            var mvm = new MedicineViewModel();   
            return View(mvm);
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Producer,GenericName")] MedicineViewModel mvm)
        {
            if (ModelState.IsValid)
            {
                IBL bl = new BLImplement();
                Medicine medicine = new Medicine()
                {
                    Name = mvm.Name,
                    GenericName = mvm.GenericName,
                    ActiveIngredients = mvm.ActiveIngredients,
                    PortionProperties = mvm.PortionProperties,
                    Producer = mvm.Producer
                    
                };
                bl.addMedicine(medicine);
                return RedirectToAction("Index");
            }

            return View(medicineViewModel);
        }

        // GET: Medicines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            Medicine medicine = bl.getAllMedicines().ToList().FindAll(x => x.Id == id).FirstOrDefault();
            if (medicine == null)
            {
                return HttpNotFound();
            }
            MedicineViewModel mvm = new MedicineViewModel()
            {
                Name = medicine.Name,
                GenericName = medicine.GenericName,
                ActiveIngredients = medicine.ActiveIngredients,
                Producer = medicine.Producer,
                PortionProperties = medicine.PortionProperties
            };
            return View(mvm);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Producer,GenericName")] MedicineViewModel medicineViewModel)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(medicineViewModel).State = EntityState.Modified;
                return RedirectToAction("Index");
            }
            return View(medicineViewModel);
        }

        // GET: Medicines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            Medicine medicine = bl.getAllMedicines().ToList().FindAll(x => x.Id == id).FirstOrDefault();
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IBL bl = new BLImplement();
            Medicine medicine = bl.getAllMedicines().ToList().FindAll(x => x.Id == id).FirstOrDefault();
            bl.deleteMedicine(medicine);
            return RedirectToAction("Index");
        }
/*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
*/
    }
}
