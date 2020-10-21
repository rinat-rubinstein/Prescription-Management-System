using PrescriptionBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrescriptionUI.Models
{
    public class GraphModel
    {
        
        public int[][] mat { get; set; }

        [DisplayName("Changing the month range in the graph:")]
        public int month { get; set; }
        public int AdministratorId { get; set; }
        public int[] CategoryId { get; set; }
        public MultiSelectList Categories { get; set; }
        public GraphModel()
        {
            IBL bl = new BLImplement();
            mat = null;
            month = 3;
        //    AdministratorId = bl.getAdministrator().Id;
            CategoryId = bl.getAllMedicines().Select(x => x.Id).ToArray();
        }
    }

}