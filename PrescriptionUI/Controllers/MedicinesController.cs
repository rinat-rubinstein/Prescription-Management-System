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
            List<MedicineViewModel> lst = new List<MedicineViewModel>();
            foreach (var item in bl.getAllMedicines())
            {
                lst.Add(new MedicineViewModel(item));
            }
            return View(lst);
        }

        // GET: Medicines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            Medicine medicine = bl.getAllMedicines().FirstOrDefault(x => x.Id == id);
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
        public ActionResult Create(FormCollection collection)//[Bind(Include = "Id,Name,Producer,GenericName,ActiveIngredients,PortionProperties")] MedicineViewModel mvm)
        {
            if (ModelState.IsValid)
            {
                IBL bl = new BLImplement();
                Medicine medicine = new Medicine()
                {
                    Name = collection["Name"],
                    GenericName = collection["GenericName"],
                    ActiveIngredients = collection["ActiveIngredients"],
                    PortionProperties = collection["PortionProperties"],
                    Producer = collection["Producer"]
                    
                };
                var img = collection["MImage"].ToString();
                var path = Server.MapPath(Url.Content($"~/images/{img}"));
                bl.addMedicine(medicine, path);
                bl.addMedicine(medicine);
                return RedirectToAction("Index");
            }

            return View(new MedicineViewModel());
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
            MedicineViewModel mvm = new MedicineViewModel(medicine);
            return View(mvm);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)//[Bind(Include = "Id,Name,Producer,GenericName")] MedicineViewModel mvm)
        {
            if (ModelState.IsValid)
            {
                IBL bl = new BLImplement();
                Medicine medicine = new Medicine()
                {
                    Name = collection["Name"],
                    GenericName = collection["GenericName"],
                    ActiveIngredients = collection["ActiveIngredients"],
                    PortionProperties = collection["PortionProperties"],
                    Producer = collection["Producer"]

                };
                var img = collection["MImage"].ToString();
               
                
                    var path = Server.MapPath(Url.Content($"~/images/{img}"));
                try
                {
                    bl.updateMedicine(medicine, path);
                    ViewBag.Message = String.Format("The Medicine successfully updated");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = String.Format(ex.Message);
                    return RedirectToAction("Index");
                }
            }
            return View(new MedicineViewModel());
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
            try
            {
                IBL bl = new BLImplement();
                Medicine medicine = bl.getAllMedicines().ToList().FindAll(x => x.Id == id).FirstOrDefault();
                bl.deleteMedicine(medicine);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = String.Format(ex.Message);
                return RedirectToAction("Index");
            }
        }
            
    }
}
