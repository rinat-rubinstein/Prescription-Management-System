using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionBE
{
    public class Doctor
    {
        
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public string Name { get; set; }
        public int Special { get; set; }
        public DateTime LicenseExpirationDate { get; set; }
        public override string ToString()
        {
            return $"id:{DoctorId} name:{Name} special:{Special}";
        }
    }
}
