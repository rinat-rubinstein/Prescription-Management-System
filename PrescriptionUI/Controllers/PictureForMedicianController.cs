using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrescriptionBL;

namespace PrescriptionUI.Controllers
{
    public class PictureForMedicianController : Controller
    {
        // GET: PictureForMedician
        public ActionResult Index()
        {
            // מעביר את הקריאה לפעולה אחרת כדי לא לשכתב לכן את הקוד
            return RedirectToAction("SelectImage");
        }

        // GET: PictureForMedician/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PictureForMedician/Create
        public ActionResult SelectImage()
        {
            ImageViewModel IVm = new ImageViewModel();
            return View(IVm);
        }

        // POST: PictureForMedician/Create
        [HttpPost]
        public ActionResult ShowDetails(FormCollection collection)
        {
            var ImgPath = collection["ImagePath"].ToString();
            var path = Server.MapPath(Url.Content($"~/Images/{ImgPath}"));
            ImagesTagsLogic bl = new ImagesTagsLogic();
            List<string> tags = bl.GetTags(path);
            return View(tags);
        }

        // GET: PictureForMedician/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PictureForMedician/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PictureForMedician/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PictureForMedician/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
