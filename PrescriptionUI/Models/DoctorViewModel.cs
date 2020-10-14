using PrescriptionBE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PrescriptionUI.Models
{
    public class DoctorViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Special { get; set; }
        [DisplayName("License ExpirationDate")]
        public string LicenseExpirationDate { get; set; }
        public override string ToString()
        {
            return $"id:{Id} name:{Name} special:{Special}";
        }
        public DoctorViewModel(Doctor doctor)
        {
            Id = doctor.Id;
            Name = doctor.Name;
            Special = doctor.Special;
            LicenseExpirationDate = doctor.LicenseExpirationDate.ToString();
        }
        public DoctorViewModel()
        {
            Id = null;
            Name = null;
            LicenseExpirationDate = null;
        }
    }
}