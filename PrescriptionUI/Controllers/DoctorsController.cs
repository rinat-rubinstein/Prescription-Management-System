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
    public class DoctorsController : Controller
    {

        // GET: Doctors
        public ActionResult Index(string searchString="")
        {
            IBL bl = new BLImplement();
            List<DoctorViewModel> lst = new List<DoctorViewModel>();
            foreach (var item in bl.getAllDoctors())
            {
                lst.Add(new DoctorViewModel(item));
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                lst = lst.Where(s => s.Name.Contains(searchString) || s.SpecialName.Contains(searchString)).ToList();
            }
            return View(lst);
        }

        // GET: Doctors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            Doctor doctor = bl.getAllDoctors().ToList().FindAll(x => x.DoctorId == id).FirstOrDefault();
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
                try
                {
                    if (!bl.getAllSpecialties().ToList().Exists(a => a.SpecialtyName == dvm.SpecialName))
                        bl.addSpecialty(new Specialty { SpecialtyName = dvm.SpecialName });
                }
                catch (Exception ex)
                {
                    ViewBag.Message = String.Format(ex.Message);
                    return RedirectToAction("Create");
                }
                if (!bl.getAllSpecialties().ToList().Exists(a => a.SpecialtyName == dvm.SpecialName))
                    bl.addSpecialty(new Specialty { SpecialtyName = dvm.SpecialName });
                Doctor doctor = new Doctor()
                {
                    Name = dvm.Name,
                    LicenseExpirationDate = Convert.ToDateTime(dvm.LicenseExpirationDate),
                    Special = bl.getAllSpecialties().Where(s => s.SpecialtyName == dvm.SpecialName).FirstOrDefault().Id
                };
                try
                {
                    bl.addDoctor(doctor);
                    ViewBag.Message = String.Format("The doctor {0} is successfully added", doctor.Name);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = String.Format(ex.Message);
                    return RedirectToAction("Index");
                }
               
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
            Doctor doctor = bl.getAllDoctors().ToList().FindAll(x => x.DoctorId == id).FirstOrDefault();
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
        public ActionResult Edit([Bind(Include = "Id,Name,Special,LicenseExpirationDate")] DoctorViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IBL bl = new BLImplement();
                    var doctor = new Doctor()
                    {
                        DoctorId = dvm.Id,
                        Name = dvm.Name,
                        LicenseExpirationDate = Convert.ToDateTime(dvm.LicenseExpirationDate),
                        Special =bl.getAllSpecialties().Where(s => s.SpecialtyName == dvm.SpecialName).FirstOrDefault().Id

                    };                
                    bl.updateDoctor(doctor);
                    ViewBag.Message = String.Format("The doctor {0} is successfully updated", doctor.Name);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = String.Format(ex.Message);
                    return RedirectToAction("Index");
                }
                //db.Entry(doctorViewModel).State = EntityState.Modified;
                return RedirectToAction("Index");
            }
            return View(dvm);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            Doctor doctor = bl.getAllDoctors().ToList().FindAll(x => x.DoctorId == id).FirstOrDefault();
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
            try
            {
                IBL bl = new BLImplement();
                Doctor doctor = bl.getAllDoctors().ToList().FindAll(x => x.DoctorId == id).FirstOrDefault();
                bl.deleteDoctor(doctor);
                ViewBag.Message = String.Format("The doctor {0} is successfully deledted", doctor.Name);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = String.Format(ex.Message);
                return RedirectToAction("Delete");
            }

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
