using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionBE
{
    public class Administrator
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return $"id:{Id} name:{UserName} password:{Password}";
        }
    }
}
