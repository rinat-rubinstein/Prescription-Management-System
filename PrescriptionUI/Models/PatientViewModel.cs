using PrescriptionBE;
using PrescriptionBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrescriptionUI.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public string Name { get; set; }
        public List<int> Prescriptions { get; set; }
        public override string ToString()
        {
            return $"id:{Id} name:{Name}";
        }
        public PatientViewModel(Patient patient)
        {
            IBL bl = new BLImplement();
            Id = patient.Id;
            Name = patient.Name;
            PatientId = patient.PatientId;
            Prescriptions = bl.allPrescriptionFromPatient(patient).Select(p=>p.Id).ToList();
        }
        public PatientViewModel()
        {
            Name = null;
            Prescriptions = null;
        }
    }
}