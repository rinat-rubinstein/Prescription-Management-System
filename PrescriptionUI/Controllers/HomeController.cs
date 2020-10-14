using PrescriptionBE;
using PrescriptionBL;
using PrescriptionDAL;
using PrescriptionUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PrescriptionUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        //ADMINISTRATOR LOGIN

        public ActionResult AdministratorEntrance()
        {
            return View(new AdministratorViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdministratorEntrance([Bind(Include = "Name,Password")] AdministratorViewModel avm)
        {
            try
            {
                IBL bl = new BLImplement();
               if( bl.isAdministrator(avm.UserName,avm.Password))
                return RedirectToAction("AdministratorOptions");
               else
                    return View("AdministratorEntrance");
            }
            catch (Exception ex)
            {
                ViewBag.Message = String.Format(ex.Message);
                return View("AdministratorEntrance");
            }
        }
        public ActionResult AdministratorOptions(GraphModel gm=null)
        {
            IBL bl = new BLImplement();
            var categories =bl.getAllMedicines().Select(c => new {
                    CategoryID = c.Id,
                    CategoryName = c.Name
                }).ToList();
                ViewBag.Categories = new MultiSelectList(categories, "CategoryID", "CategoryName");
            if (gm != null)
            {
                var medicinesId = bl.getAllMedicines().Select(x => x.Id);
                var medicinesNames = bl.getAllMedicines().Select(x => x.Name).ToArray();
                gm.mat = bl.MedicinesStatistics(gm.CategoryId, gm.month, ref medicinesNames);
            }
            else
            {
                gm = new GraphModel();
            }
            return View(gm);
        }
  
        public ActionResult EditAdministrator(int id)
        {
           return RedirectToAction("Edit", "Administrator");        
        }

        //DOCTOR (LOGIN and prescriptionIssuance)

        public ActionResult DoctorEntrance()
        {
            return View(new DoctorViewModel());
        }    

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoctorEntrance([Bind(Include = "Id,Name,LicenseExpirationDate")] DoctorViewModel dvm)
        {
            try
            {
                IBL bl = new BLImplement();
               bl.IsDoctor(dvm.Name,dvm.Id,dvm.LicenseExpirationDate);
                return RedirectToAction("DoctorOptions");
            }
            catch (Exception ex)
            {
                ViewBag.Message = String.Format(ex.Message);
                return View("DoctorEntrance");
            }
        }
        public ActionResult DoctorOptions()
        {
            return View();
        }

        public ActionResult prescriptionIssuance(string id)
        {
            IBL bl = new BLImplement();
            var pfpm = new PrescriptionForPatientModel();
            pfpm.Patient = bl.getAllPatients().FirstOrDefault(x=>x.Id==id);
            pfpm.prescription.Patient = id;           
            return View(pfpm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult prescriptionIssuance([Bind(Include = "medicine,StartDate,EndDate,Doctor,Cause")] PrescriptionForPatientModel pfpm)
        {
            try
            {
                IBL bl = new BLImplement();
                var prescription = new Prescription()
                {
                    medicine = bl.getAllMedicines().FirstOrDefault(x => x.Name == pfpm.prescription.medicine).Id,//change the name to the id
                    StartDate = Convert.ToDateTime(pfpm.prescription.StartDate),
                    EndDate = Convert.ToDateTime(pfpm.prescription.EndDate),
                    Doctor = bl.getAllDoctors().FirstOrDefault(x => x.Name == pfpm.prescription.Doctor).Id,
                    Patient =pfpm.Patient.Id,
                    Cause = pfpm.prescription.Cause
                };
                bl.addPrescription(prescription);
                ViewBag.Message = String.Format("The prescription for {0} is successfully added.",pfpm.Patient.Name);
                return RedirectToAction("DoctorOptions");
            }
            catch (Exception ex)
            {
                ViewBag.Message = String.Format(ex.Message);
                return View("prescriptionIssuance");
            }
        }
        public ActionResult medicalHistory(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            //-----------
            //var lst=bl.getPrescriptionById(id);
            //return RedirectToAction("Index",Prescription,lst);
            //----------
            //TODO: create the right Prescription Controller
            return View();
        }
    }
}