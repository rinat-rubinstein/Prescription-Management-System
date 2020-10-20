using PrescriptionBE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using PrescriptionBL;

namespace PrescriptionUI.Models
{
    public class DoctorViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SpecialName { get; set; }
        [DisplayName("License Expiration Date")]
        public DateTime LicenseExpirationDate { get; set; }
        public List<string> specials { get; set; }
        public override string ToString()
        {
            return $"id:{Id} name:{Name} special:{SpecialName}";
        }
        public DoctorViewModel(Doctor doctor)
        {
            IBL bl = new BLImplement();
            Id = doctor.DoctorId;
            Name = doctor.Name;
            SpecialName =bl.getAllSpecialties().Where(s=>s.Id== doctor.Special).FirstOrDefault().SpecialtyName;
            LicenseExpirationDate = doctor.LicenseExpirationDate;
            specials = bl.getAllSpecialties().Select(x => x.SpecialtyName).ToList();
        }
        public DoctorViewModel()
        {
            IBL bl = new BLImplement();
            Id = null;
            Name = null;
            LicenseExpirationDate = DateTime.MinValue;
            specials = bl.getAllSpecialties().Select(x => x.SpecialtyName).ToList();
        }
    }
}