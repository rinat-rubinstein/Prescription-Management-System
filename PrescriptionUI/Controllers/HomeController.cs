using PrescriptionBE;
using PrescriptionBL;
using PrescriptionDAL;
using PrescriptionUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PrescriptionUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        //ADMINISTRATOR LOGIN

        public ActionResult AdministratorEntrance()
        {

            return View(new AdministratorViewModel());
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AdministratorEntrance(string UserName, string Password)
        {
            try
            {
                IBL bl = new BLImplement();
                if (bl.isAdministrator(UserName, Password))
                    return RedirectToAction("AdministratorOptions", "Administrator", bl.getAllAdministrators().FirstOrDefault(a => a.UserName == UserName && a.Password == Password));
                else
                    return RedirectToAction("AdministratorEntrance");
            }
            catch (Exception ex)
            {

                ViewBag.Message = String.Format(ex.Message);
                return RedirectToAction("AdministratorEntrance");
            }
        }
          
        //DOCTOR (LOGIN and prescriptionIssuance)

        public ActionResult DoctorEntrance()
        {
            return View(new DoctorViewModel());
        }    

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult DoctorEntrance(FormCollection collection)//string Name, DateTime LicenseExpirationDate)
        {
            try
            {
                IBL bl = new BLImplement();
                var d = bl.IsDoctor(collection["Name"], Convert.ToDateTime(collection["LicenseExpirationDate"]));
                if (d != null)
                {
                    return RedirectToAction("DoctorOptions", "Doctor", d);
                }
                else
                {
                    return RedirectToAction("DoctorEntrance");
                }
            }
            catch (Exception ex)
            {

                ViewBag.Message = String.Format(ex.Message);
                return RedirectToAction("DoctorEntrance");
            }
        }  
    }
}