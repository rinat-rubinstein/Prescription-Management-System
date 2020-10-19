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
        //[ValidateAntiForgeryToken]
        public ActionResult AdministratorEntrance(string UserName, string Password)
        {
            try
            {
                IBL bl = new BLImplement();
               if( bl.isAdministrator(UserName,Password))
                 return RedirectToAction("Index","Administrator",bl.getAllAdministrators().FirstOrDefault(a=> a.UserName==UserName && a.Password==Password));
                //return RedirectToAction("AdministratorOptions");
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
            return View();
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
        public ActionResult DoctorEntrance(string Name, DateTime LicenseExpirationDate)
        {
            try
            {
                IBL bl = new BLImplement();
                var d = bl.IsDoctor(Name, LicenseExpirationDate);
                if (d != null)
                {
                    return RedirectToAction("Index", "Doctors", d);
                }
                else
                {
                    return View("DoctorEntrance");
                }

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