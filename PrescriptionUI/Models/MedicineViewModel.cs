using PrescriptionBE;
using PrescriptionBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PrescriptionUI.Models
{
    public class MedicineViewModel
    {
        public int Id { get; set; }

        [DisplayName("Medicine Name")]
        public string Name { get; set; }
        public string Producer { get; set; }
        [DisplayName("Generic Name")]
        public string GenericName { get; set; }
        public string ActiveIngredients { get; set; }
        public string PortionProperties { get; set; }

        [DisplayName("Upload File")]
        public string Picture { get; set; }
        public override string ToString()
        {
            return $"id:{Id} name:{Name}";
        }
        public MedicineViewModel()
        {
            Name = null;
            Producer = null;
            ActiveIngredients = null;
            PortionProperties = null;
            GenericName = null;
            Picture = null;
        }
        public MedicineViewModel(Medicine medicine)
        {
            IBL bl = new BLImplement();
            this.Id = medicine.Id;
            this.Name = medicine.Name;
            this.GenericName = medicine.GenericName;
            this.PortionProperties = medicine.PortionProperties;
            this.Producer = medicine.Producer;
            this.Picture = bl.getMedicinePicture(Id);
        }
    }
}