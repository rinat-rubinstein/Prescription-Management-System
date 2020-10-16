using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrescriptionBL;
using PrescriptionUI.Models;

namespace PrescriptionUI.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            IBL bl = new BLImplement();
            List<DoctorViewModel> lst = new List<DoctorViewModel>();
            foreach (var item in bl.getAllDoctors())
            {
                lst.Add(new DoctorViewModel(item));
            }
            lst.Add(new DoctorViewModel(new PrescriptionBE.Doctor() { Id = "1", LicenseExpirationDate = DateTime.Now, Name = "Chain Mochr", Special = 4 }));
            lst.Add(new DoctorViewModel(new PrescriptionBE.Doctor() { Id = "1", LicenseExpirationDate = DateTime.Now, Name = "Rinar Robin", Special = 5 }));
            lst.Add(new DoctorViewModel(new PrescriptionBE.Doctor() { Id = "1", LicenseExpirationDate = DateTime.Now, Name = "Roti Fri", Special = 8 }));
            return View(lst);
        }

        // GET: Doctor/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
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

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctor/Edit/5
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

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctor/Delete/5
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
