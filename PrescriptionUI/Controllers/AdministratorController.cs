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
        public ActionResult AdministratorOptions(Administrator administrator, GraphModel gm = null)
        {
            IBL bl = new BLImplement();
            var categories = bl.getAllMedicines().Select(c => new {
                CategoryID = c.Id,
                CategoryName = c.Name
            }).ToList();
            ViewBag.Categories = new MultiSelectList(categories, "CategoryID", "CategoryName");
            if (gm != null)
            {
                var medicinesId = bl.getAllMedicines().Select(x => x.Id);
                var medicinesNames = bl.getAllMedicines().Select(x => x.Name).ToArray();
                gm.mat = bl.MedicinesStatistics(gm.CategoryId, gm.month, ref medicinesNames);
            }
            else
            {
                gm = new GraphModel();
            }
            return View(gm);
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
