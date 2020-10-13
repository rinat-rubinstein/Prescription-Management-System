using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionDAL.MedicineInteraction
{
    class FullInteractionTypeGroup
    {
        public string sourceDisclaimer { get; set; }
        public string sourceName { get; set; }
        public List<FullInteractionType> fullInteractionType { get; set; }
    }
}
