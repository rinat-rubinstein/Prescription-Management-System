using PrescriptionBE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using PrescriptionBL;
namespace PrescriptionUI.Models
{
    public class PrescriptionViewModel
    {
        public int Id { get; set; }
        public string medicine { get; set; }
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public string Cause { get; set; }

        public PrescriptionViewModel(Prescription p)
        {
            IBL bl = new BLImplement();
            this.Id = p.Id;
            this.medicine = bl.getMedicine(p.medicine).Name;
            this.StartDate = p.StartDate;
            this.EndDate = p.EndDate;
            this.Doctor=bl.getDoctor( p.Doctor).Name;
            this.Patient = bl.getPatient( p.Patient).Name;
            this.Cause = p.Cause;
        }
    }

}