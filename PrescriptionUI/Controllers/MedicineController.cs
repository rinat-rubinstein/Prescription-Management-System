using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrescriptionBL;
using PrescriptionUI.Data;
using PrescriptionUI.Models;

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
            return View();
        }

        // POST: Medicine/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medicine/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
