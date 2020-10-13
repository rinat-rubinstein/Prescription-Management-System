using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionBE
{
    public class Prescription
    {
        public int Id { get; set; }
        public int medicine { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Doctor { get; set; }
        public int Patient { get; set; }
        public string Cause { get; set; }
        public override string ToString()
        {
            return $"id:{Id} medicineId:{medicine} startDate:{StartDate} endDate:{EndDate} doctorId:{Doctor} patientId:{Patient}";
        }
    }
}
