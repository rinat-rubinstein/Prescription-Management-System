﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionDAL.MedicineInteraction
{
    class InteractionPair
    {
        public List<InteractionConcept> interactionConcept { get; set; }
        public string severity { get; set; }
        public string description { get; set; }
    }
}
