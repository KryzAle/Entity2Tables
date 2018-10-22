using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblioteca2;

namespace Biblioteca2.Controllers
{
    public class LibroController : Controller
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: Libro
        public ActionResult Index()
        {
            var libro = db.Libro.Include(l => l.Sucursal);
            return View(libro.ToList());
        }

        // GET: Libro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            ViewBag.suc_id = new SelectList(db.Sucursal, "suc_id", "suc_nom");
            return View();
        }

        // POST: Libro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lib_id,lib_nombre,lib_precio,lib_isbn,suc_id")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Libro.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.suc_id = new SelectList(db.Sucursal, "suc_id", "suc_nom", libro.suc_id);
            return View(libro);
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.suc_id = new SelectList(db.Sucursal, "suc_id", "suc_nom", libro.suc_id);
            return View(libro);
        }

        // POST: Libro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lib_id,lib_nombre,lib_precio,lib_isbn,suc_id")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.suc_id = new SelectList(db.Sucursal, "suc_id", "suc_nom", libro.suc_id);
            return View(libro);
        }

        // GET: Libro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libro libro = db.Libro.Find(id);
            db.Libro.Remove(libro);
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
