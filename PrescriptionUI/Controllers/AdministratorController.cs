using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrescriptionUI.Data;
using PrescriptionUI.Models;

namespace PrescriptionUI.Controllers
{
    public class AdministratorController : Controller
    {
        private PrescriptionUIContext db = new PrescriptionUIContext();

        // GET: Administrator
        public ActionResult Index()
        {
            return View(db.AdministratorViewModels.ToList());
        }

        // GET: Administrator/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministratorViewModel administratorViewModel = db.AdministratorViewModels.Find(id);
            if (administratorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(administratorViewModel);
        }

        // GET: Administrator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password")] AdministratorViewModel administratorViewModel)
        {
            if (ModelState.IsValid)
            {
                db.AdministratorViewModels.Add(administratorViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administratorViewModel);
        }

        // GET: Administrator/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministratorViewModel administratorViewModel = db.AdministratorViewModels.Find(id);
            if (administratorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(administratorViewModel);
        }

        // POST: Administrator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password")] AdministratorViewModel administratorViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administratorViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administratorViewModel);
        }

        // GET: Administrator/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministratorViewModel administratorViewModel = db.AdministratorViewModels.Find(id);
            if (administratorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(administratorViewModel);
        }

        // POST: Administrator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdministratorViewModel administratorViewModel = db.AdministratorViewModels.Find(id);
            db.AdministratorViewModels.Remove(administratorViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
