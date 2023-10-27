using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Categorycrud.Models;
using PagedList;
using PagedList.Mvc;

namespace Categorycrud.Controllers
{
    public class Product8Controller : Controller
    {
        private NimapEntities5 db = new NimapEntities5();

       
        
        public ActionResult Index(int?page)
        {
            var product8 = db.Product8.Include(p => p.Category9).Include(p => p.Category91);

            //return View(product8.ToList());
            return View(product8.ToList().ToPagedList(page ?? 1, 10));
        }

    
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product8 product8 = db.Product8.Find(id);
            if (product8 == null)
            {
                return HttpNotFound();
            }
            return View(product8);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category9, "CategoryId", "CategoryName");
            ViewBag.CategoryName = new SelectList(db.Category9, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,CategoryId,CategoryName")] Product8 product8)
        {
            if (ModelState.IsValid)
            {
                db.Product8.Add(product8);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Category9, "CategoryId", "CategoryName", product8.CategoryId);
            ViewBag.CategoryName = new SelectList(db.Category9, "CategoryId", "CategoryName", product8.CategoryName);
            return View(product8);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product8 product8 = db.Product8.Find(id);
            if (product8 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category9, "CategoryId", "CategoryName", product8.CategoryId);
            ViewBag.CategoryName = new SelectList(db.Category9, "CategoryId", "CategoryName", product8.CategoryName);
            return View(product8);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,CategoryId,CategoryName")] Product8 product8)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product8).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Category9, "CategoryId", "CategoryName", product8.CategoryId);
            ViewBag.CategoryName = new SelectList(db.Category9, "CategoryId", "CategoryName", product8.CategoryName);
            return View(product8);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product8 product8 = db.Product8.Find(id);
            if (product8 == null)
            {
                return HttpNotFound();
            }
            return View(product8);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product8 product8 = db.Product8.Find(id);
            db.Product8.Remove(product8);
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
