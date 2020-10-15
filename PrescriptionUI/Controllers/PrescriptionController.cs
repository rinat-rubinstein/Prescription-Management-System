using PrescriptionBE;
using PrescriptionBL;
using PrescriptionUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrescriptionUI.Controllers
{
    public class PrescriptionController : Controller
    {
        // GET: Prescription
        public ActionResult Index(string id)//IEnumerable<Prescription> prescriptions)
        {
            IBL bl = new BLImplement();
            var patient = bl.getAllPatients().FirstOrDefault(x => x.Id == id);
            var prescriptions = bl.allPrescriptionFromPatient(patient);
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
            return View(pvm);
        }
    }
}
