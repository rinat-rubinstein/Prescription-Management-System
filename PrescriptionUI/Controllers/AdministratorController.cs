using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrescriptionBE;
using PrescriptionBL;
using PrescriptionUI.Data;
using PrescriptionUI.Models;

namespace PrescriptionUI.Controllers
{
    public class AdministratorController : Controller
    {
        public ActionResult AdministratorOptions(Administrator administrator)
        {
            return View();
        }
        // GET: Administrator/Edit/5
         public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBL bl = new BLImplement();
            var administrator = bl.getAdministrator(id);
            var avm = new AdministratorViewModel(administrator);
            if (avm == null)
            {
                return HttpNotFound();
            }
            return View(avm);
        }

        // POST: Administrator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password")] AdministratorViewModel avm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IBL bl = new BLImplement();
                    var administrator = new Administrator()
                    {
                        Id = avm.Id,
                        UserName = avm.UserName,
                        Password = avm.Password
                    };
                    bl.updateAdministrator(administrator);
                    ViewBag.Message = String.Format("Your details are successfully updated");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = String.Format(ex.Message);
                    return RedirectToAction("AdministratorEntrance");
                }
                return RedirectToAction("AdministratorEntrance");
            }
            return RedirectToAction("AdministratorEntrance");
        }       
    }
}
