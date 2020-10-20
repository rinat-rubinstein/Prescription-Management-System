using PrescriptionBE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PrescriptionUI.Models
{
    /// <summary>
    /// to delete later, just fill the folder 'model'
    /// </summary>
    public class AdministratorViewModel
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return $"id:{Id} name:{UserName} password:{Password}";
        }
        public AdministratorViewModel()
        {
            Id = 0;
            UserName = null;
            Password = null;
        }
        public AdministratorViewModel(Administrator administrator)
        {
            Id = administrator.Id;
            UserName = administrator.UserName;
            Password = administrator.Password;
        }
    }
}