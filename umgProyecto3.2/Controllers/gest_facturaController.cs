using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using umgProyecto3._2.Models;

namespace PROYECTO_WEB.Controllers
{
    public class gest_facturaController : Controller
    {
        private webEntities1 db = new webEntities1();

        // GET: gest_factura
        public ActionResult Index()
        {
            var gest_factura = db.gest_factura.Include(g => g.mov_factura_credito);
            return View(gest_factura.ToList());
        }

        // GET: gest_factura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gest_factura gest_factura = db.gest_factura.Find(id);
            if (gest_factura == null)
            {
                return HttpNotFound();
            }
            return View(gest_factura);
        }

        // GET: gest_factura/Create
        public ActionResult Create()
        {
            ViewBag.serie = new SelectList(db.mov_factura_credito, "serie", "cancelado");
            return View();
        }

        // POST: gest_factura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "serie,estado,fecha")] gest_factura gest_factura)
        {
            if (ModelState.IsValid)
            {
                db.insert_factura(gest_factura.serie,gest_factura.estado,gest_factura.fecha);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.serie = new SelectList(db.mov_factura_credito, "serie", "cancelado", gest_factura.serie);
            return View(gest_factura);
        }

        // GET: gest_factura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gest_factura gest_factura = db.gest_factura.Find(id);
            if (gest_factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.serie = new SelectList(db.mov_factura_credito, "serie", "cancelado", gest_factura.serie);
            return View(gest_factura);
        }

        // POST: gest_factura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "serie,estado,fecha")] gest_factura gest_factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gest_factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.serie = new SelectList(db.mov_factura_credito, "serie", "cancelado", gest_factura.serie);
            return View(gest_factura);
        }

        // GET: gest_factura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gest_factura gest_factura = db.gest_factura.Find(id);
            if (gest_factura == null)
            {
                return HttpNotFound();
            }
            return View(gest_factura);
        }

        // POST: gest_factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gest_factura gest_factura = db.gest_factura.Find(id);
            db.gest_factura.Remove(gest_factura);
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
