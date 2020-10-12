using PrescriptionBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrescriptionUI.Models
{
    public class PrescriptionForPatientModel
    {
        public Patient Patient { get; set; }
        public PrescriptionViewModel prescription{get;set;}
    }
}