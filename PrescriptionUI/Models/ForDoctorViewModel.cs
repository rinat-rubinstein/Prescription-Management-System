using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrescriptionBE;
using PrescriptionBL;

namespace PrescriptionUI.Models
{
    public class ForDoctorViewModel
    {
        public Doctor doctor { get; set; }
        public List<PatientViewModel> patients { get; set; }

        public ForDoctorViewModel()
        {
            doctor = new Doctor() { Name = "" };
        }
        public ForDoctorViewModel(Doctor d){
            this.doctor = d;
            IBL bl = new BLImplement();
            var p = bl.getAllPatients();
            patients = new List<PatientViewModel>();
            foreach (var item in p)
            {
                patients.Add(new PatientViewModel(item));
            }
        }

    }
}