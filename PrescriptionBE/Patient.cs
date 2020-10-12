using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionBE
{
    public class Patient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<int> Prescriptions { get; set; }
        public override string ToString()
        {
            return $"id:{Id} name:{Name}";
        }
    }
}
