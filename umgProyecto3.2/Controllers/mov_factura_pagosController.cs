using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using umgProyecto3._2.Models;

namespace umgProyecto3._2.Controllers
{
    public class mov_factura_pagosController : Controller
    {
        private webEntities1 db = new webEntities1();

        // GET: mov_factura_pagos
        public ActionResult Index()
        {
            var mov_factura_pagos = db.mov_factura_pagos.Include(m => m.gest_proveedor).Include(m => m.usuario);
            return View(mov_factura_pagos.ToList());
        }

        // GET: mov_factura_pagos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mov_factura_pagos mov_factura_pagos = db.mov_factura_pagos.Find(id);
            if (mov_factura_pagos == null)
            {
                return HttpNotFound();
            }
            return View(mov_factura_pagos);
        }

        // GET: mov_factura_pagos/Create
        public ActionResult Create()
        {
            ViewBag.empresa = new SelectList(db.gest_proveedor, "codigo", "nombre");
            
            return View();
        }

        // POST: mov_factura_pagos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "correlativo,nfactura,descripcion,Total,empresa,cancelado,fecha_factura,fecha_ingreso,id_user")] mov_factura_pagos mov_factura_pagos)
        {

           
            if (ModelState.IsValid)
            {
                DateTime Hoy = DateTime.Today;

                string fecha_actual = Hoy.ToString("dd-MM-yyyy");
                mov_factura_pagos.fecha_ingreso = DateTime.Parse(fecha_actual);
                mov_factura_pagos.cancelado = "No";

                mov_factura_pagos.id_user = Convert.ToInt32(Session["id"]);
                db.insert_facturacp(mov_factura_pagos.nfactura, mov_factura_pagos.descripcion, mov_factura_pagos.Total, mov_factura_pagos.empresa, mov_factura_pagos.cancelado, mov_factura_pagos.fecha_factura, mov_factura_pagos.fecha_ingreso, mov_factura_pagos.id_user);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.empresa = new SelectList(db.gest_proveedor, "codigo", "nombre", mov_factura_pagos.empresa);
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre", mov_factura_pagos.id_user);
            return View(mov_factura_pagos);
        }

        // GET: mov_factura_pagos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mov_factura_pagos mov_factura_pagos = db.mov_factura_pagos.Find(id);
            if (mov_factura_pagos == null)
            {
                return HttpNotFound();
            }
            ViewBag.empresa = new SelectList(db.gest_proveedor, "codigo", "nombre", mov_factura_pagos.empresa);
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre", mov_factura_pagos.id_user);
            return View(mov_factura_pagos);
        }

        // POST: mov_factura_pagos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "correlativo,nfactura,descripcion,Total,empresa,cancelado,fecha_factura,fecha_ingreso,id_user")] mov_factura_pagos mov_factura_pagos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mov_factura_pagos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.empresa = new SelectList(db.gest_proveedor, "codigo", "nombre", mov_factura_pagos.empresa);
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre", mov_factura_pagos.id_user);
            return View(mov_factura_pagos);
        }

        // GET: mov_factura_pagos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mov_factura_pagos mov_factura_pagos = db.mov_factura_pagos.Find(id);
            if (mov_factura_pagos == null)
            {
                return HttpNotFound();
            }
            return View(mov_factura_pagos);
        }

        // POST: mov_factura_pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mov_factura_pagos mov_factura_pagos = db.mov_factura_pagos.Find(id);
            db.mov_factura_pagos.Remove(mov_factura_pagos);
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
