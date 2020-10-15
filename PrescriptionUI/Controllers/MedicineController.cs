using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using PrescriptionBL;
using PrescriptionUI.Data;
using PrescriptionUI.Models;
using PrescriptionBE;
using System.Net;

namespace PrescriptionUI.Controllers
{
    //tryyyyyyy--------------------------------------------------------------------------
    public class MedicineController : Controller
    {
        // GET: Medicine
        public ActionResult Index()
        {
            IBL bl = new BLImplement();
            List<MedicineViewModel> lst = new List<MedicineViewModel>();
            foreach (var item in bl.getAllMedicines())
            {
                lst.Add(new MedicineViewModel(item));
            }
            lst.Add(new MedicineViewModel(new PrescriptionBE.Medicine() { Id = 1, Name = "acamol", ActiveIngredients = "attt", GenericName = "122-654", PortionProperties = "sdf", Producer = "f" }));
            lst.Add(new MedicineViewModel(new PrescriptionBE.Medicine() { Id = 2, Name = "nerufen", ActiveIngredients = "attt", GenericName = "165-876", PortionProperties = "sdf", Producer = "f" }));

            return View(lst);
        }

        // GET: Medicine/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Medicine/Create
        public ActionResult Create()
        {
            var mvm = new MedicineViewModel();
            return View(mvm);
        }

        // POST: Medicine/Create
        [HttpPost]
        public ActionResult Create(MedicineViewModel mvm)
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
                try
                {
                    bl.addMedicine(medicine, mvm.ImageFile);
                    ViewBag.Message = String.Format("The medicine {0} is successfully added", medicine.Name);
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

        // GET: Medicine/Edit/5
        public ActionResult Edit(int id)
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

        // POST: Medicine/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medicine/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Medicine/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
