using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Categorycrud.Models;

namespace Categorycrud.Controllers
{
    public class Category9Controller : Controller
    {
        private NimapEntities5 db = new NimapEntities5();

        
        public ActionResult Index()
        {
            return View(db.Category9.ToList());
        }

      
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category9 category9 = db.Category9.Find(id);
            if (category9 == null)
            {
                return HttpNotFound();
            }
            return View(category9);
        }

        
        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName")] Category9 category9)
        {
            if (ModelState.IsValid)
            {
                db.Category9.Add(category9);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category9);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category9 category9 = db.Category9.Find(id);
            if (category9 == null)
            {
                return HttpNotFound();
            }
            return View(category9);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName")] Category9 category9)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category9).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category9);
        }

     
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category9 category9 = db.Category9.Find(id);
            if (category9 == null)
            {
                return HttpNotFound();
            }
            return View(category9);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category9 category9 = db.Category9.Find(id);
            db.Category9.Remove(category9);
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
