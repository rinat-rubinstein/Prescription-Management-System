using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrescriptionBL;
using PrescriptionUI;
using PrescriptionUI.Models;

namespace PrescriptionUI.Controllers
{
    public class GraphController : Controller
    {
        // GET: Graph
        public ActionResult Graph(string name="", int year=0)
        {
            IBL bl = new BLImplement();
            MedicineInfo md = new MedicineInfo();
            try
            {
                md.MedicineList = bl.getAllMedicines().ToList();
            }
            catch (Exception ex)
            {
                ViewBag.Message = String.Format(ex.Message);
                return View("Graph");

            }
            if ((year <= 0) || (name == ""))
            {
                md.MedicineName = "";
            }
            else
            {
                //string MedicineName = bl.GetMedicine(id.ToString()).Name.ToString();
                List<int> prescription = bl.info(name, year);
                md.MedicineName = name;
                md.medicineArray = prescription.ToArray();
            }
            return View("Graph", md);
        }

    }
}

