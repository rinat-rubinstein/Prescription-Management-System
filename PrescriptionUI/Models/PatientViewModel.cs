using PrescriptionBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrescriptionUI.Models
{
    public class PatientViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<int> Prescriptions { get; set; }
        public override string ToString()
        {
            return $"id:{Id} name:{Name}";
        }
        public PatientViewModel(Patient patient)
        {
            Id = patient.Id;
            Name = patient.Name;
            Prescriptions = patient.Prescriptions;
        }
        public PatientViewModel()
        {
            Name = null;
            Prescriptions = null;
        }
    }
}