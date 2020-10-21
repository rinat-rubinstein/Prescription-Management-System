using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrescriptionBL;
using PrescriptionBE;
using PrescriptionUI.Models;
using System.Web.UI.WebControls;

namespace PrescriptionUI.Controllers
{
    public class PrescriptionController : Controller
    {
        // GET: Prescription
        public ActionResult Index(string id)//IEnumerable<Prescription> prescriptions)
        {
            IBL bl = new BLImplement();
            var patient = bl.getPatient(id);
            if(patient==null)
            {
                patient = bl.getAllPatients().FirstOrDefault(X => X.Name == id);//when return to list
            }
            var prescriptions = bl.allPrescriptionFromPatient(patient);
            if (prescriptions==null)
            {
                ViewBag.Message = String.Format("There are no prescription for {0} yet",patient.Name);
                return RedirectToAction("DoctorOptions");
            }
            var lst = new List<PrescriptionViewModel>();
            foreach (var item in prescriptions)
            {
                lst.Add(new PrescriptionViewModel(item));
            }
            return View(lst);
        }

        // GET: Prescription/Details/5
        public ActionResult Details(int id)
        {
            IBL bl = new BLImplement();           
            var pvm = new PrescriptionViewModel(bl.getAllPrescriptions().FirstOrDefault(x => x.Id == id));
            ViewBag.Patient = pvm.Patient;
            return View(pvm);
        }
    }
}