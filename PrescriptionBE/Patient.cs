using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionBE
{
    public class Patient
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"id:{PatientId} name:{Name}";
        }
    }
}
