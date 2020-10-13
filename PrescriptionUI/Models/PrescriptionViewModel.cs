using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PrescriptionUI.Models
{
    public class PrescriptionViewModel
    {
        public string Id { get; set; }
        public string medicine { get; set; }
        [DisplayName("Start Date")]
        public string StartDate { get; set; }
        [DisplayName("End Date")]
        public string EndDate { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public string Cause { get; set; }
    }
}