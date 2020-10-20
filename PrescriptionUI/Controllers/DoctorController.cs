using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrescriptionBL;
using PrescriptionUI.Models;
using PrescriptionBE;
using System.Net;

namespace PrescriptionUI.Controllers
{
    public class DoctorController : Controller
    {
        public ActionResult DoctorOptions(Doctor doctor=null)
        {
            var fdvm = new ForDoctorViewModel(doctor);
            return View(fdvm);
        }

        public ActionResult prescriptionIssuance(string id, string doctor)
        {
            IBL bl = new BLImplement();
            var d= bl.getDoctor(doctor);
            if(doctor==null)
            {
                ViewBag.Message = String.Format("please enter again");
                return RedirectToAction("DoctorEntrance","Home");
            }
            
            var pfpm = new PrescriptionForPatientModel();
            pfpm.prescription.Patient = id;
            pfpm.prescription.Doctor = doctor;
            pfpm.patient = id;
            pfpm.doctor = doctor;
            return View(pfpm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult prescriptionIssuance(FormCollection collection)///*string medicine*/, DateTime StartDate, DateTime EndDate, string Doctor, string Patient, string Cause)
        {
            try
            {
                IBL bl = new BLImplement();
                Prescription prescription = new Prescription()
                {
                    medicine = bl.getAllMedicines().FirstOrDefault(x => x.Name == collection["medicine"]).Id,//change the name to the id
                    StartDate =Convert.ToDateTime( collection["StartDate"]),
                    EndDate = Convert.ToDateTime(collection["EndDate"]),
                    Doctor = collection["Doctor"],
                    Patient = collection["Patient"],
                    Cause = collection["prescription.Cause"]
                };
                bl.addPrescription(prescription);
                ViewBag.Message = String.Format("The prescription for {0} is successfully added. You can watch {1}'s medical history for full details. ", collection["medicine"].ToString() /*, bl.getPatient(prescription.Patient).Name.ToString()*/);
                return RedirectToAction("DoctorOptions",prescription.Doctor);
            }
            catch (Exception ex)
            {
                ViewBag.Message = String.Format(ex.Message);
                return RedirectToAction("prescriptionIssuance");
            }
        }
        //public ActionResult medicalHistory(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    return RedirectToAction("Index", "Prescription", id);
        //}
    }
}
