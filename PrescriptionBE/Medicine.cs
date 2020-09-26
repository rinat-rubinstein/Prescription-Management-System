using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionBE
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string GenericName { get; set; }
        public List<string> ActiveIngredients { get; set; }
        public List<string> PortionProperties { get; set; }
        public override string ToString()
        {
            return $"id:{Id} name:{Name}";
        }
    }
}
