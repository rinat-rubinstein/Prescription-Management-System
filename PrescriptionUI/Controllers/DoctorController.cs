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
        public ActionResult DoctorOptions(Doctor doctor)
        {
            /*for exe: */
            doctor = new Doctor() { Id = "123", Name = "Danni" };
            var fdvm = new ForDoctorViewModel(doctor);
            return View(fdvm);
        }

        public ActionResult prescriptionIssuance(string id, Doctor doctor)
        {
            IBL bl = new BLImplement();
            var pfpm = new PrescriptionForPatientModel();
            pfpm.prescription.Patient = id;
            pfpm.prescription.Doctor = doctor.Id;
            return View(pfpm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult prescriptionIssuance(string medicine, DateTime StartDate, DateTime EndDate, string Doctor, string Patient, string Cause)
        {
            try
            {
                IBL bl = new BLImplement();
                var prescription = new Prescription()
                {
                    medicine = bl.getAllMedicines().FirstOrDefault(x => x.Name == medicine).Id,//change the name to the id
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Doctor = Doctor,
                    Patient = Patient,
                    Cause = Cause
                };
                bl.addPrescription(prescription);
                ViewBag.Message = String.Format("The prescription for {0} is successfully added. You can watch {1}'s medical history for full details. ", medicine /*bl.getMedicine(prescription.medicine).Name*/, bl.getPatient(Patient).Name);
                return RedirectToAction("DoctorOptions");
            }
            catch (Exception ex)
            {
                ViewBag.Message = String.Format(ex.Message);
                return RedirectToAction("prescriptionIssuance");
            }
        }
        public ActionResult medicalHistory(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Index", "Prescription", id);
        }
    }
}
