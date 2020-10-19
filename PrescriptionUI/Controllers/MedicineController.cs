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
    public class MedicineController : Controller
    {
        // GET: Medicine
        public ActionResult Index(string searchString="")
        {
            IBL bl = new BLImplement();
            List<MedicineViewModel> lst = new List<MedicineViewModel>();             
            var temp = bl.getAllMedicines().Where(a => a.Id <= 100).ToList();
            foreach (var item in temp)
            {
                lst.Add(new MedicineViewModel(item));
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                lst = lst.Where(s => s.Name.Contains(searchString) || s.GenericName.Contains(searchString)).ToList();
            }
            return View(lst);
        }

        // GET: Medicine/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            Medicine medicine = bl.getMedicine(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            var mvm = new MedicineViewModel(medicine);
            return View(mvm);
        }

        // GET: Medicine/Create
        public ActionResult Create()
        {
            var mvm = new MedicineViewModel();
            return View(mvm);
        }

        // POST: Medicine/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicineViewModel mvm, HttpPostedFileBase ImageFile)
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
                    if (ImageFile != null)
                    {
                        bl.addMedicine(medicine);
                    }
                    else
                    {
                        bl.addMedicine(medicine, ImageFile);
                    }
                    bl.addMedicine(medicine, ImageFile);
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
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            Medicine medicine = bl.getMedicine(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            MedicineViewModel mvm = new MedicineViewModel(medicine);
            return View(mvm);
        }

        // POST: Medicine/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MedicineViewModel mvm, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                IBL bl = new BLImplement();
                Medicine medicine = new Medicine()
                {
                    Id=mvm.Id,
                    Name = mvm.Name,
                    GenericName = mvm.GenericName,
                    ActiveIngredients = mvm.ActiveIngredients,
                    PortionProperties = mvm.PortionProperties,
                    Producer = mvm.Producer

                };
                try
                {
                    if (ImageFile != null)
                    { bl.updateMedicinePicture(medicine.Id, ImageFile); }                   
                    bl.updateMedicine(medicine);
                    ViewBag.Message = String.Format("The Medicine {0} successfully updated", medicine.Name);
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

        // GET: Medicine/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            Medicine medicine = bl.getMedicine(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            MedicineViewModel mvm = new MedicineViewModel(medicine);
            return View(mvm);
        }

        // POST: Medicine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                IBL bl = new BLImplement();
                Medicine medicine = bl.getMedicine(id);
                bl.deleteMedicine(medicine);
                ViewBag.Message = String.Format("The medicine {0} is successfully deleted", medicine.Name);
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
