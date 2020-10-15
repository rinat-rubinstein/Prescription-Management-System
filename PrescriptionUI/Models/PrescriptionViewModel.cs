using PrescriptionBE;
using PrescriptionBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PrescriptionUI.Models
{
    public class PrescriptionViewModel
    {
        public int Id { get; set; }
        public string medicine { get; set; }
        [DisplayName("Start Date")]
        public string StartDate { get; set; }
        [DisplayName("End Date")]
        public string EndDate { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public string Cause { get; set; }
        public PrescriptionViewModel(Prescription prescription)
        {
            IBL bl = new BLImplement();
            Id = prescription.Id;
            medicine =bl.getAllMedicines().FirstOrDefault(x=>x.Id==prescription.medicine).Name;
            StartDate = prescription.StartDate.ToString();
            EndDate = prescription.EndDate.ToString();
            Doctor = prescription.Doctor;
            Patient = prescription.Patient;
            Cause = prescription.Cause;
        }
    }
}