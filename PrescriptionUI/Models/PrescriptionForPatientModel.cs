using PrescriptionBE;
using PrescriptionBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrescriptionUI.Models
{
    public class PrescriptionForPatientModel
    {
        public string doctor { get; set; }
        public string patient { get; set; }
        public PrescriptionViewModel prescription { get; set; }
        public List<string> medicines { get; set; }
        public PrescriptionForPatientModel()
        {
            IBL bl = new BLImplement();
            this.prescription = new PrescriptionViewModel();
            var lst = bl.getAllMedicines().ToList();
            this.medicines = new List<string>();
            foreach (var item in lst)
            {
                medicines.Add(item.Name);
            }
        }
    }
}