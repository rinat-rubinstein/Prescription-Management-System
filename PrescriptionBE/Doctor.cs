﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionBE
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Special { get; set; }
        public override string ToString()
        {
            return $"id:{Id} name:{Name} special:{Special}";
        }
    }
}